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
    internal class Type_PokemonConfig : IEntityTypeConfiguration<Type_Pokemon>
    {
        public void Configure(EntityTypeBuilder<Type_Pokemon> builder)
        {
            builder.HasKey(k => new { k.TypeId, k.PokemonId });

            builder.HasOne(p => p.PokemonType).WithMany(x => x.Pokemons)
                   .HasForeignKey(x => x.TypeId);

            builder.HasOne(p => p.Pokemon).WithMany(x => x.Types)
                    .HasForeignKey(x => x.PokemonId);
        }
    }
}
