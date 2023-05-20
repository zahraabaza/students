using System.Net.Http.Json;

namespace students_web.Services.BaseService
{
    public class BaseService<Dto> : IBaseService<Dto> where Dto : class
    {
        private readonly HttpClient _httpClient;
        private readonly string endpoint;

        public BaseService(HttpClient httpClient, string path)
        {
            _httpClient = httpClient;
            endpoint = "api/" + path + "/";
        }

        public async Task<IEnumerable<Dto>> GetAll()
        {

            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<Dto>>(endpoint);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
