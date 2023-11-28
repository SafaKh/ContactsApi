using ContactsApi.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return await _contactService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact is null) return NotFound("Contact not found");

            return contact;
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            return await _contactService.CreateContact(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(int id, Contact request)
        {
            var contacts = await _contactService.UpdateContact(id, request);
            if (contacts is null) return NotFound("Contact not found");

            return contacts;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var contacts = await _contactService.DeleteContact(id);
            if (contacts is null) return NotFound("Contact not found");

            return contacts;
        }
    }
}
