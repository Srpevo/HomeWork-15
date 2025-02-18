using UniversityProgram.Data.Repositories.AddressesRepository.Abstract;
using UniversityProgram.Data.Repositories.AddressesRepository.Impl;
using UniversityProgram.Data.Repositories.CoursesRepository.Abstract;
using UniversityProgram.Data.Repositories.CoursesRepository.Impl;
using UniversityProgram.Data.Repositories.CpusRepository.Abstract;
using UniversityProgram.Data.Repositories.CpusRepository.Impl;
using UniversityProgram.Data.Repositories.LaptopsRepository.Abstract;
using UniversityProgram.Data.Repositories.LaptopsRepository.Impl;
using UniversityProgram.Data.Repositories.LibrariesRepository.Abstract;
using UniversityProgram.Data.Repositories.LibrariesRepository.Impl;
using UniversityProgram.Data.Repositories.StudentsRepository.Abstract;
using UniversityProgram.Data.Repositories.StudentsRepository.Impl;
using UniversityProgram.Data.Repositories.UnitOfWork.Abstract;
using UniversityProgram.Data.Repositories.UniversitiesRepository.Abstract;
using UniversityProgram.Data.Repositories.UniversitiesRepository.Impl;

namespace UniversityProgram.Data.Repositories.UnitOfWork.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public UnitOfWork(StudentDbContext context)
        {
            _context = context;
            InitalizeRepositories(context);
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

        public void InitalizeRepositories(StudentDbContext context)
        {
            CourseRepository = new CourseRepository(context);
            StudentRepository = new StudentRepository(context);
            AddressRepository = new AddressRepository(context);
            CpuRepository = new CpuRepository(context);
            LaptopsRepository = new LaptopRepository(context);
            LibraryRepository = new LibraryRepository(context);
            UniversityRepository = new UniversityRepository(context);
        }
    }
}
