using System.Net.Http.Json;
using UniversityProgram.UI.Apis.StudentApi.Abstarct;
using UniversityProgram.UI.Models.StudentModels;

namespace UniversityProgram.UI.Apis.StudentApi.Impl
{
    public class StudentApi : IStudentApi
    {
        private readonly HttpClient _http;

        public StudentApi(HttpClient http)
        {
            _http = http;
        }

        public async Task Add(StudentAddModel model)
        {
            await _http.PostAsJsonAsync("/Students", model);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"/Students/{id}");
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            return await _http.GetFromJsonAsync<IEnumerable<StudentModel>>("/Students");
        }

        public async Task<StudentModel> GetById(int id)
        {
            return await _http.GetFromJsonAsync<StudentModel>($"/Students/{id}");
        }

        public async Task Update(int id, StudentUpdateModel model)
        {
            await _http.PutAsJsonAsync($"/Students/{id}", model);
        }
    }
}
