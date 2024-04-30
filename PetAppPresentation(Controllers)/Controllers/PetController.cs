using Microsoft.AspNetCore.Mvc;
using PetAppBusiness.Models.Implementations;
using PetAppBusiness.Services.Interfaces;

namespace PetAppPresentation_Controllers_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {

        private readonly IPetService _service;
        public PetController(IPetService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authors = _service.Get();

            return Ok(authors);
        }

        [HttpGet]
        [Route("by-id/{id}")]
        public IActionResult Get(int id)
        {
            var author = _service.Get(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(PetModel model)
        {
            if (model.Id != 0)
                return BadRequest();

            int id = _service.Insert(model);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put(PetModel model)
        {
            var author = _service.Get(model.Id);

            if (author == null)
                return NotFound();

            _service.Update(model);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok();
        }

    }
}
