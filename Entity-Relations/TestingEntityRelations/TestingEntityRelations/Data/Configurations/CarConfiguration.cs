namespace TestingEntityRelations.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
               .HasOne(c => c.Model)
               .WithMany(m => m.Cars)
               .HasForeignKey(c => c.ModelId);

            car
               .HasIndex(c => c.Vin)
               .IsUnique();
        }
    }
}
