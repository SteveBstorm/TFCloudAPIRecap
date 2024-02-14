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
    public class TypeRepo : ITypeRepo
    {
        public DataContext DC { get; set; }

        public TypeRepo()
        {
            DC = new DataContext();
        }

        public void Create(PokemonType pt)
        {
            DC.Typelist.Add(pt);
            DC.SaveChanges();
        }

        public List<PokemonType> GetAll()
        {
            return DC.Typelist.ToList();
        }


    }
}
