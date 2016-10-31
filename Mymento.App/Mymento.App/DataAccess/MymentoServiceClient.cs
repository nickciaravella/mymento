namespace Mymento.App.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Mymento.App.Login;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using Xamarin.Forms;

    public class MymentoServiceClient
    {
        private static readonly Uri BaseApiUri = new Uri("http://mymento.azurewebsites.net/api/");
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<AccessToken> LoginAsync(string username, string password)
        {
            const string url = "http://mymento.azurewebsites.net/token";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.Content = new FormUrlEncodedContent(
                        new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "password"),
                            new KeyValuePair<string, string>("username", username),
                            new KeyValuePair<string, string>("password", password)
                        });

                    using (HttpResponseMessage response = await httpClient.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception("Login failed.");
                        }

                        string responseBody = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(responseBody);
                        return new AccessToken()
                        {
                            Token = (string) json["access_token"]
                        };
                    }
                }
            }
        }

        public Task<IEnumerable<Entities.Task>> GetTasksAsync() =>
            this.Get<IEnumerable<Entities.Task>>("tasks");

        private async Task<T> Get<T>(string relativeUrl)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(BaseApiUri, relativeUrl)))
            {
                request.Headers.Add("Authorization", "Bearer " + await this.GetAccessToken());

                using (HttpResponseMessage response = await HttpClient.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new HttpRequestException(
                            $"Url returned status code: {response.StatusCode}, {response.RequestMessage.RequestUri}");
                    }

                    return DeserializeResponse<T>(
                        await response.Content.ReadAsStringAsync());
                }
            }
        }

        private async Task<string> GetAccessToken()
        {
            var userCredential = await DependencyService
                .Get<IUserCredentialStore>()
                .GetCurrentUserCredentialAsync();

            if (userCredential == null)
            {
                throw new Exception("No user is logged in.");
            }

            AccessToken token = await this.LoginAsync(
                userCredential.EmailAddress,
                userCredential.Password);

            return token.Token;
        }

        private T DeserializeResponse<T>(string responseBody)
        {
            return (T)JsonConvert.DeserializeObject(
                responseBody,
                typeof(T),
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}
