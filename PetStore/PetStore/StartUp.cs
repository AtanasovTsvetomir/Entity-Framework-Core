namespace PetStore
{
    using System;

    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Implementations;

    public class StartUp
    {
        public static void Main()
        {
            //using (var data = new PetStoreDbContext())
            //{
            //    var foodService = new FoodService(data);

            //    foodService.BuyFromDistributor("Cat food", .350, 1.1m, 0.3, DateTime.Now, 2, 1);
            //}

            //--------------------------------------------------------

            //using (var data = new PetStoreDbContext())
            //{
            //    var toyService = new ToyService(data);

            //    toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);
            //}

            //--------------------------------------------------------

            //using (var data = new PetStoreDbContext())
            //{
            //    var userService = new UserService(data);
            //    var foodService = new FoodService(data , userService);

            //    //userService.Register("Pesho", "pesho123@mai.com");

            //    foodService.SellFoodToUser(1, 1);
            //}

            //------------------------------------------------------

            //using (var data = new PetStoreDbContext())
            //{
            //    var userService = new UserService(data);
            //    var toyService = new ToyService(data, userService);

            //    //userService.Register("Pesho", "pesho123@mai.com");

            //    toyService.SellToyToUser(1, 1);
            //}

            //--------------------------------------------------------


            //using (var data = new PetStoreDbContext())
            //{
            //    var userService = new UserService(data);
            //    var breedService = new BreedService(data);
            //    var categoryService = new CategoryService(data);

            //    var petService = new PetService(data, breedService, categoryService, userService);

            //    petService.BuyPet(Gender.Male, DateTime.Now, 0m, null, 1, 1);
            //    petService.SellPet(1, 1);

            //}
        }
    }
}
