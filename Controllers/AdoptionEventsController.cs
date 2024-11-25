using Db_FirstPet.Models;
using Db_FirstPet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Db_FirstPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionEventsController : ControllerBase
    {
        private readonly IAdoptionEventService _service;
        public AdoptionEventsController(IAdoptionEventService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<AdoptionEvent> events = _service.GetAllEvents();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            AdoptionEvent events = _service.GetAdoptionEventById(id);
            return Ok(events);
        }
        [HttpPost]
        public IActionResult Post(AdoptionEvent adoptionEvent)
        {
            int Result = _service.AddNewEvent(adoptionEvent);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult Put(AdoptionEvent adoptionEvent)
        {
            string result = _service.UpdateAdoptionEvent(adoptionEvent);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteAdoptionEvent(id);
            return Ok(result);
        }
    }
}
