using Client.Models;
using Client.Contracts;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Client.Utilities.Handlers;
using CLient.DTOs.Accounts;
using Client.DTOs.Accounts;

namespace Client.Repositories
{
    public class AccountRepository : GeneralRepository<Account, Guid>, IAccountRepository
    {
        public AccountRepository(string request = "accounts/") : base(request)
        {
        }
        public async Task<ResponseHandler<TokenDto>> Login(LoginDto login)
        {
            ResponseHandler<TokenDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "login", content).Result) 
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<TokenDto>>(apiResponse);
            }
            return entityVM;
        }
    }
}