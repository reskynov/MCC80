using API.Utilities;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class GeneralRepository<Entity, TId> : IRepository<Entity, TId>
        where Entity : class
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public GeneralRepository(string request)
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7123/api/")
            };
            this.request = request;
        }

        public Task<ResponseHandler<Entity>> Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseHandler<IEnumerable<Entity>>> GetAll()
        {
            ResponseHandler<IEnumerable<Entity>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<IEnumerable<Entity>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<Entity>> Get(TId id)
        {
            ResponseHandler<Entity> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<Entity>> Post(Entity entity)
        {
            ResponseHandler<Entity> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<Entity>> Put(TId id, Entity entity)
        {
            ResponseHandler<Entity> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }
    }
}