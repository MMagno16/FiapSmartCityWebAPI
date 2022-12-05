using FiapSmartCityWebAPI.Repository;
using FiapSmartCityWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public readonly AnimalRepository animalRepository;

        public AnimalController()
        {
            animalRepository = new AnimalRepository();
        }

        [HttpGet]
        [Route("GetAnimal")]
        public IActionResult Get() 
        {
            try
            {
                return Ok(new AnimalRepository().Listar());
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }
        [HttpPost(Name = "GetAnimal")]
        
        public IActionResult Post([FromBody] Animal animal)
        {
            try
            {
                new AnimalRepository().Create(animal);
                string location = "http://localhost:7013/FiapSmartCityWebAPI";

                return Created(new Uri(location), animal);
            }
            catch (Exception)
            {
                return BadRequest();
                throw new Exception("Erro ao cadastrar os dados no banco");
            }
        }

        [HttpDelete(Name = "GetAnimal")]
        public IActionResult Delete(int id)
        {
            try
            {
                animalRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw new Exception("Erro ao cadastrar os dados no banco");

            }
        }

            [HttpPut(Name = "GetAnimal")]
            public IActionResult Edit([FromBody] Animal animal)
            {
                try
                {
                    animalRepository.Edit(animal);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                    throw new Exception("Erro ao cadastrar os dados no banco");

                }
            }
        }
    }

    