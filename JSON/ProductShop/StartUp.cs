using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                var result = GetUsersWithProducts(db);

                Console.WriteLine(result);
            }
        }

        // Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        
        // Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<Category[]>(inputJson);

            var categoriesToAdd = new List<Category>();

            foreach (var currentName in input)
            {
                if (currentName.Name != null)
                {
                    categoriesToAdd.Add(currentName);
                }
            }

            context.Categories.AddRange(categoriesToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToAdd.Count}";
        }

        // Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validCategoryIds = new HashSet<int>(
                context
                    .Categories
                    .Select(c => c.Id));

            var validProductIds = new HashSet<int>(
                context
                    .Products
                    .Select(p => p.Id));

            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoriesProducts)
            {
                bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) &&
                               validProductIds.Contains(categoryProduct.ProductId);

                if (isValid)
                {
                    validEntities.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validEntities);
            context.SaveChanges();

            return $"Successfully imported {validEntities.Count()}";
        }
        // Export Products in range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //Export Successfully sold products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(i => i.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(i =>i.Buyer != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //Export Categories by Products count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(p => p.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts
                        .Select(p => p.Product.Price).Average().ToString("F2"),
                    totalRevenue = c.CategoryProducts
                        .Select(p => p.Product.Price).Sum().ToString("F2")
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        // Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count,
                        products = u.ProductsSold
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var usersOutput = new
            {
                usersCount = users.Count,
                users = users
            };

            var json = JsonConvert.SerializeObject(usersOutput, new
                JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

    }
}