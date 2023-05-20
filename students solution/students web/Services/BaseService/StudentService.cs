using Dtos.Pagination;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace students_web.Services.BaseService
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StudentDto> Add(StudentDto studentDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<StudentDto>("api/student/add", studentDto);

                return await response.Content.ReadFromJsonAsync<StudentDto>();
            }catch (Exception)
            {
                throw;
            }
        }

        public async Task<StudentDto> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/student?id={id}");

                return await response.Content.ReadFromJsonAsync<StudentDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetAll(int CurrentPage, int ItemPerPage)
        {

            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<StudentDto>>($"api/student?PageNumber={CurrentPage}&PageSize={ItemPerPage}");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetByParentId(int parentId, int CurrentPage, int ItemPerPage)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<StudentDto>>($"api/student/GetByParentId/{parentId}?PageNumber={CurrentPage}&PageSize={ItemPerPage}");

            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<StudentDto> Update(StudentDto studentDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<StudentDto>("api/student/update", studentDto);

                return await response.Content.ReadFromJsonAsync<StudentDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
