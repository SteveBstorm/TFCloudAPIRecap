using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCloudAPIRecap.DAL.Interfaces;

namespace TFCloudAPIRecap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepo _typeRepo;

        public TypeController(ITypeRepo typeRepo)
        {
            _typeRepo = typeRepo;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            return Ok(_typeRepo.GetAll());
        }

        [HttpPost]
        public IActionResult Post(TypeForm tf) 
        {
            _typeRepo.Create(new DAL.Entities.PokemonType
            {
                Name = tf.Name
            });
            return Ok();
        }


    }
}

public class TypeForm
{
    public string Name { get; set; }
}