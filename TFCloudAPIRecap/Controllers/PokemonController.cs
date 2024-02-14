using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCloudAPIRecap.DAL.Entities;
using TFCloudAPIRecap.DAL.Interfaces;
using TFCloudAPIRecap.DTO;

namespace TFCloudAPIRecap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepo _pokemonRepo;
        private readonly IType_PokemonRepo _typeRepo;

        public PokemonController(IPokemonRepo pokemonRepo, IType_PokemonRepo typeRepo)
        {
            _pokemonRepo = pokemonRepo;
            _typeRepo = typeRepo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] PokemonForm pokemon)
        {
            try
            {
                int id  = _pokemonRepo.Create(new Pokemon
                {
                    Race = pokemon.Race,
                    Height = pokemon.Height,
                    HP = pokemon.HP,
                    ImageURL = pokemon.ImageURL
                });
                foreach(int type in pokemon.TypeIds)
                {
                    _typeRepo.Create(id, type);
                }
                return Ok();
            }
            catch (Exception ex) { return  BadRequest(ex.Message); }
        
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pokemonRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            return Ok(_pokemonRepo.GetById(id));        
        }
    }
}
