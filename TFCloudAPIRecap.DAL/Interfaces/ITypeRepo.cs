using TFCloudAPIRecap.DAL.Entities;

namespace TFCloudAPIRecap.DAL.Interfaces
{
    public interface ITypeRepo
    {
        void Create(PokemonType pt);
        List<PokemonType> GetAll();
    }
}