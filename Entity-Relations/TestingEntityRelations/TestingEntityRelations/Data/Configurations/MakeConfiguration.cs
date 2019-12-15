namespace TestingEntityRelations.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
               .HasIndex(m => m.Name)
               .IsUnique();

            //----Many-To-One relationship.
            make
               .HasMany(m => m.Models)
               .WithOne(m => m.Make)
               .HasForeignKey(m => m.MakeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
