

using UniversityProgram.Data.Repositories.AddressesRepository;
using UniversityProgram.Data.Repositories.CoursesRepository;
using UniversityProgram.Data.Repositories.CpusRepository;
using UniversityProgram.Data.Repositories.LaptopsRepository;
using UniversityProgram.Data.Repositories.LibrariesRepository;
using UniversityProgram.Data.Repositories.StudentsRepository;
using UniversityProgram.Data.Repositories.UniversitiesRepository;
using UniversityProgram.Domain.BaseRepositories;

namespace UniversityProgram.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public UnitOfWork(StudentDbContext context)
        {
            _context = context;

            CourseRepository = new CourseRepository(context);
            StudentRepository = new StudentRepository(context);
            AddressRepository = new AddressRepository(context);
            CpuRepository = new CpuRepository(context);
            LaptopsRepository = new LaptopRepository(context);
            LibraryRepository = new LibraryRepository(context);
            UniversityRepository = new UniversityRepository(context);
        }

        public ICourseRepository CourseRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public ICpuRepository CpuRepository { get; set; }
        public ILaptopRepository LaptopsRepository { get; set; }
        public IUniversityRepository UniversityRepository { get; set; }
        public ILibraryRepository LibraryRepository { get; set; }       

        public async Task Save(CancellationToken token = default)
        {
            await _context.SaveChangesAsync(token);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
