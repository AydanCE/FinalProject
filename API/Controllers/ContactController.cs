using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("GetAllContacts")]
        public IActionResult GetAll()
        {
            var r = _contactService.GetAllContacts();
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
        [HttpPost("AddContact")]
        public IActionResult Add(Contact contact)
        {
            var r = _contactService.AddContact(contact);
            if(r.Success)
                return Ok(r);
            return BadRequest(r);
        }
    }
}
