namespace PetStore.Services
{
    using System.Collections.Generic;

    using Models.Brand;
    using PetStore.Models;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToyServiceModel FindByIdWithToys(int id);
    }
}
