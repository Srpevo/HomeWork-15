using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using UniversityProgram.UI.Dialogs;
using UniversityProgram.UI.Models.StudentModels;

namespace UniversityProgram.UI.Pages
{
    public partial class Students
    {
        private List<StudentModel> _students = new();
        private HubConnection _connection = default!;

        private async Task Setup()
        {
            _connection = new HubConnectionBuilder()
          .WithUrl("http://localhost:5260/studentshub")
          .WithAutomaticReconnect()
          .Build();

            _connection.On<string>("ReceiveMessage", async (message) =>
            {
                if (message.ToLower() == "slu")
                {
                    await LoadStudentsAsync();
                    StateHasChanged();
                }
            });

            await _connection.StartAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            await Setup();
            await LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            _students = (await StudentApi.GetAll()).ToList();
        }

        private async Task AddStudent()
        {
            var dialog = await DialogService.ShowAsync<AddStudentDialog>();
            var result = await dialog.Result;
            if (result!.Canceled) return;
            snackbar.Add("Student Added", Severity.Info);
            await _connection.SendAsync("SendMessage", "slu");
            await LoadStudentsAsync();
        }

        private async Task EditStudent(int id)
        {
            var @params = new DialogParameters<UpdateStudentDialog> { { x => x.Id, id } };
            var dialog = await DialogService.ShowAsync<UpdateStudentDialog>("", @params);
            var result = await dialog.Result;
            if (result!.Canceled) return;
            snackbar.Add("Student Updated", Severity.Info);
            await _connection.SendAsync("SendMessage", "slu");
            await LoadStudentsAsync();
        }

        private async Task DeleteStudentAsync(int id)
        {
            await StudentApi.Delete(id);
            snackbar.Add("Student Deleted", Severity.Success);
            await _connection.SendAsync("SendMessage", "slu");
            await LoadStudentsAsync();
        }
    }
}