﻿namespace TestingEntityRelations.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Customer;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public ICollection<CarPurchase> Purchases { get; set; } = new HashSet<CarPurchase>();
    }
}
