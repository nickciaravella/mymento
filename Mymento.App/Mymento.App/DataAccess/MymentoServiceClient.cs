namespace Mymento.App.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class MymentoServiceClient
    {
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
    }
}
