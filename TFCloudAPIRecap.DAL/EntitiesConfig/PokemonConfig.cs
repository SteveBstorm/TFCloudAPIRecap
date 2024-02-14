using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCloudAPIRecap.DAL.Entities;

namespace TFCloudAPIRecap.DAL.EntitiesConfig
{
    internal class PokemonConfig : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Race).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_hp", "HP > 0"));


        }
    }
}
