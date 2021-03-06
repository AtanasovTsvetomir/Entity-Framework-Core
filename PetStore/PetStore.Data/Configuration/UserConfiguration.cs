﻿namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
