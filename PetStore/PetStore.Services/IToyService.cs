namespace PetStore.Services
{
    using PetStore.Services.Models.Toy;

    public interface IToyService
    {
        void BuyFromDistributor(string name, string desciption, decimal distributorPrice,
            double profit, int brandId, int categoryId);

        void BuyFromDistributor(AddinToyServiceModel model);

        void SellToyToUser(int toyId, int userId);

        bool Exists(int toyId);
    }
}
