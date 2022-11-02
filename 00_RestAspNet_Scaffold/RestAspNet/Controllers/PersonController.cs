using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Filters;
using RestAspNet.Services.Implementations;
using System.Collections.Generic;

namespace RestAspNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpGet("findPersonByName")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult FindPersonByName([FromQuery] string firstName, string lastName)
        {
            var person = _personService.FindByName(firstName, lastName);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Post([FromBody] PersonVO  person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Put([FromBody] PersonVO  person)
        {
            if (person == null) return BadRequest();

            return Ok(_personService.Update(person));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Patch(long id)
        {
            var person = _personService.Disabled(id);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }
    }
}
