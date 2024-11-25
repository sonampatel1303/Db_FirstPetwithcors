using Db_FirstPet.Models;
using Db_FirstPet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Db_FirstPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _service;
        public ParticipantsController(IParticipantService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Participant> participant = _service.GetAllpartcipants();
            return Ok(participant);
        }
        [HttpGet("{id}")]
        public IActionResult GetParticpantById(int id)
        {
            Participant participant = _service.GetParticipantById(id);
            return Ok(participant);
        }
        [HttpPost]
        public IActionResult Post(Participant participant)
        {
            int Result = _service.AddNewParticipant(participant);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult Put(Participant participant)
        {
            string result = _service.UpdateParticipant(participant);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteParticipant(id);
            return Ok(result);
        }

    }
}
