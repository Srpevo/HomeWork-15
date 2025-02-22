
namespace UniversityProgram.Domain.BaseRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ICourseRepository CourseRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public ICpuRepository CpuRepository { get; set; }
        public ILaptopRepository LaptopsRepository { get; set; }
        public IUniversityRepository UniversityRepository { get; set; }
        public ILibraryRepository LibraryRepository { get; set; }

       
        public Task Save(CancellationToken token = default);
    }
}
