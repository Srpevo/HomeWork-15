using AutoMapper;
using FluentValidation;
using Moq;
using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.AddressModels.ViewModels;
using UniversityProgram.BLL.Services.AddressService.Abstract;
using UniversityProgram.BLL.Services.AddressService.Impl;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Tests
{
    public class AddressServiceTests
    {
        private IAddressService _addressService;

        private Mock<IAddressRepository> _addressRepositoryMock = new Mock<IAddressRepository>(MockBehavior.Strict);
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);
        private Mock<IMapper> _mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        private Mock<IValidator<AddressAddModel>> _validatorMock = new Mock<IValidator<AddressAddModel>>(MockBehavior.Strict);

        public AddressServiceTests()
        {
           
            _unitOfWorkMock.SetupGet(u => u.AddressRepository).Returns(_addressRepositoryMock.Object);

            _addressService = new AddressService(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetById_Success()
        {
            // Arrange
            const int id = 1;
            var address = new Address { Id = id };
            var addressModel = new AddressModel { Id = id };

            _addressRepositoryMock.Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(address);

            _mapperMock.Setup(m => m.Map<AddressModel>(It.IsAny<Address>()))
                .Returns((Address src) => new AddressModel { Id = src.Id });

            // Act
            var result = await _addressService.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);

            _addressRepositoryMock.Verify(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()), Times.Once);
            _mapperMock.Verify(m => m.Map<AddressModel>(It.IsAny<Address>()), Times.Once);
        }

    }

}
