using Microsoft.AspNetCore.Components;
using MudBlazor;
using UniversityProgram.UI.Models.StudentModels;

namespace UniversityProgram.UI.Dialogs
{
    public partial class UpdateStudentDialog
    {

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }
        private StudentUpdateModel Student { get; set; } = new();
    
        private async Task Update()
        {
            await StudentApi.Update(Id, Student);
            MudDialog.Close(DialogResult.Ok(true));
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}