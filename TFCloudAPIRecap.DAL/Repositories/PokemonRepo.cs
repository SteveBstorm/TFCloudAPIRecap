using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCloudAPIRecap.DAL.Context;
using TFCloudAPIRecap.DAL.Entities;
using TFCloudAPIRecap.DAL.Interfaces;

namespace TFCloudAPIRecap.DAL.Repositories
{
    public class PokemonRepo : IPokemonRepo
    {
        public DataContext DC { get; set; }

        public PokemonRepo()
        {
            DC = new DataContext();
        }

        public List<Pokemon> GetAll()
        {
            return DC.Pokedex.ToList();
        }

        public int Create(Pokemon p)
        {
            DC.Pokedex.Add(p);
            DC.SaveChanges();
            
            return p.Id ?? 0;
        }

        public void Delete(int Id)
        {
            DC.Pokedex.Remove(DC.Pokedex.First(p => p.Id == Id));
        }

        public Pokemon GetById(int Id)
        {
            return DC.Pokedex.Include(p => p.Types)
                 .ThenInclude(tp => tp.PokemonType)
                 .ToList().First(p => p.Id == Id);
        }

        public List<Pokemon> GetByType(int id) 
        {
            return DC.Pokedex.Where(p => p.Types.First(x => x.TypeId == id) != null).ToList(); 
        }
    }
}
