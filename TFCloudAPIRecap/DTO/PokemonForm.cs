namespace TFCloudAPIRecap.DTO
{
    public class PokemonForm
    {
        public string Race { get; set; }
        public int Height { get; set; }
        public int HP { get; set; }
        public string ImageURL { get; set; }

        public List<int> TypeIds { get; set; }
    }

}
