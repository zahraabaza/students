using Dtos.Parent;
using Dtos.Student;
using System.Net.Http.Json;

namespace students_web.Services.BaseService
{
    public class ParentService : IParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ParentDto> Add(ParentDto parent)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ParentDto>("api/parent/add", parent);

                return await response.Content.ReadFromJsonAsync<ParentDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/parent?id={id}");

                return await response.Content.ReadFromJsonAsync<ParentDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ParentDto>> GetAll(int CurrentPage, int ItemPerPage)
        {
            try{
                return await _httpClient.GetFromJsonAsync<IEnumerable<ParentDto>>($"api/parent?PageNumber={CurrentPage}&PageSize={ItemPerPage}");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ParentDto>> GetAll()
        {
            try{
                return await _httpClient.GetFromJsonAsync<IEnumerable<ParentDto>>($"api/parent/GetAll");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentDto> Update(ParentDto parent)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<ParentDto>("api/parent/update", parent);

                return await response.Content.ReadFromJsonAsync<ParentDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ParentDto>> Search(string keyword, int CurrentPage, int ItemPerPage)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<ParentDto>>($"api/parent/search/{keyword}?PageNumber={CurrentPage}&PageSize={ItemPerPage}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
