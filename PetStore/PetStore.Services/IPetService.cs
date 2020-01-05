namespace PetStore.Services
{
    using System;
    
    using PetStore.Models;

    public interface IPetService
    {
        void BuyPet(Gender gender, DateTime dateTime, decimal price,
            string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
