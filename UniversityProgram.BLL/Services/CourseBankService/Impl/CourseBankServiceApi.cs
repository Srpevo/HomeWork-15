using UniversityProgram.BLL.Services.CourseBankService.Abstract;

namespace UniversityProgram.BLL.Services.CourseBankService.Impl
{
    public class CourseBankServiceApi : ICourseBankService
    {
        //Կեղծ փոխանցում համալսարանի հաշվեհամարին
        public bool PayCourse(int id)
        {
            if (id == 2)
            {
                return true;
            }

            throw new Exception("Բանկն անհասանելի է");
        }
    }
}
