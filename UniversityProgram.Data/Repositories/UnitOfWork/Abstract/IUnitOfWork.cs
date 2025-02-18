using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProgram.Data.Repositories.AddressesRepository.Abstract;
using UniversityProgram.Data.Repositories.CoursesRepository.Abstract;
using UniversityProgram.Data.Repositories.CpusRepository.Abstract;
using UniversityProgram.Data.Repositories.LaptopsRepository.Abstract;
using UniversityProgram.Data.Repositories.LibrariesRepository.Abstract;
using UniversityProgram.Data.Repositories.LibrariesRepository.Impl;
using UniversityProgram.Data.Repositories.StudentsRepository.Abstract;
using UniversityProgram.Data.Repositories.UniversitiesRepository.Abstract;

namespace UniversityProgram.Data.Repositories.UnitOfWork.Abstract
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

        public void InitalizeRepositories(StudentDbContext context);
        public Task Save(CancellationToken token = default);
    }
}
