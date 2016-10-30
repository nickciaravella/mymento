namespace Mymento.Service.Api.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Mymento.Common.Validation;
    using Mymento.Service.Api.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    public class TasksStore
    {
        private static readonly Lazy<DocumentClient> DocumentClient = new Lazy<DocumentClient>(() =>
            new DocumentClient(
                new Uri(ConfigurationManager.AppSettings.Get("DocumentDbServerUri")),
                ConfigurationManager.AppSettings.Get("DocumentDbServerKey")));

        public async Task<IEnumerable<TaskModel>> GetTasks(string userId)
        {
            userId.ArgumentShouldNotBeNullOrWhitespace(nameof(userId));

            ResourceResponse<Document> response = await this.ReadUserDocumentAsync(userId);
            return this.DeserializeTo<IEnumerable<TaskModel>>(response.Resource, "tasks");
        }

        private Task<ResourceResponse<Document>> ReadUserDocumentAsync(string userId) =>
            DocumentClient.Value.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(
                    "user-data-db",
                    "user-data",
                    userId),
                new RequestOptions()
                {
                    PartitionKey = new PartitionKey(userId)
                });

        private T DeserializeTo<T>(Document document, string objectPath)
        {
            JObject jDocument = JObject.Parse(document.ToString());
            return JsonConvert.DeserializeObject<T>(
                jDocument[objectPath].ToString(),
                new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}