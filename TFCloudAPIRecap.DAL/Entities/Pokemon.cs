using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFCloudAPIRecap.DAL.Entities
{
    public class Pokemon
    {
        public int? Id { get; set; }
        public string Race { get; set; }
        public int Height { get; set; }
        public int HP { get; set; }
        public string ImageURL { get; set; }
        public List<Type_Pokemon>? Types { get; set; }

    }
}
