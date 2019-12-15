namespace TestingEntityRelations.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Make;

    public class Make
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; } = new HashSet<Model>();
    }
}
