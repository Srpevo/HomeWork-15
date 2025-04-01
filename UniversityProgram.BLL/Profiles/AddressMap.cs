using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.AddressModels.ViewModels;
using UniversityProgram.Domain.Entities;


namespace UniversityProgram.BLL.Profiles
{
    public static class AddressMap
    {
        public static AddressModel Map(this Address address)
        {
            return new AddressModel
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                Country = address.Country
            };
        }

        public static Address Map(this AddressAddModel? model)
        {
            if (model is null) return null!;

            return new Address
            {
                City = model.City,
                Street = model.Street,
                Country = model.Country
            };
        }



    }
}
