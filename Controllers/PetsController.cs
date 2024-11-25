using Db_FirstPet.Models;
using Db_FirstPet.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Db_FirstPet.Controllers
{        
[EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _service;
        public PetsController(IPetService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pet> pet = _service.GetAllPets();
            return Ok(pet);
        }
       // [EnableCors("AllowSpecificOrigin")]
        [HttpGet("{id}")]
        public IActionResult GetPetById(int id)
        {
           Pet pet = _service.GetPetById(id);
            return Ok(pet);
        }
        [HttpPost]
        public IActionResult Post(Pet pet)
        {
            int Result = _service.AddNewPet(pet);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult Put(Pet pet)
        {
            string result = _service.UpdatePet(pet);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeletePet(id);
            return Ok(result);
        }


    }
}
