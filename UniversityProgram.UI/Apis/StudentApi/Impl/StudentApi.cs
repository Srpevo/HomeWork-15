using System.Net.Http.Json;
using UniversityProgram.UI.Apis.StudentApi.Abstarct;
using UniversityProgram.UI.Models;

namespace UniversityProgram.UI.Apis.StudentApi.Impl
{
    public class StudentApi : IStudentApi
    {
        private readonly HttpClient _http;

        public StudentApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            return await _http.GetFromJsonAsync<IEnumerable<StudentModel>>("/Students");
        }
    }
}
