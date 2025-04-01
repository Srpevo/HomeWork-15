using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniversityProgram.UI.Models.StudentModels;

namespace UniversityProgram.UI.Dialogs
{
    public partial class AddStudentDialog
    {

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }
        private StudentAddModel Student { get; set; } = new();

        private async Task Add()
        {
            await StudentApi.Add(Student);
            MudDialog.Close(DialogResult.Ok(true));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}