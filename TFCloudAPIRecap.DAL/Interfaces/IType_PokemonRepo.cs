using TFCloudAPIRecap.DAL.Entities;

namespace TFCloudAPIRecap.DAL.Interfaces
{
    public interface IType_PokemonRepo
    {
        void Create(int pokemonId, int typeId);
        IEnumerable<Type_Pokemon> GetAll();
    }
}