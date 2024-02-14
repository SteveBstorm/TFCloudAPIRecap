using TFCloudAPIRecap.DAL.Entities;

namespace TFCloudAPIRecap.DAL.Interfaces
{
    public interface IPokemonRepo
    {
        int Create(Pokemon p);
        void Delete(int Id);
        List<Pokemon> GetAll();
        Pokemon GetById(int Id);
    }
}