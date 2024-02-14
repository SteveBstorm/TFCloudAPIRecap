using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCloudAPIRecap.DAL.Entities
{
    public class Type_Pokemon
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        public int TypeId { get; set; }
        public PokemonType PokemonType{ get; set; }
    }
}
