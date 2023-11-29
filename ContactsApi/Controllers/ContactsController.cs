using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            try 
            {
                var contacts = await _contactService.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all contacts.");
                return StatusCode(500, "An error occurred while retrieving contacts.");
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            try
            {
                var contact = await _contactService.GetContactById(id);
                if (contact is null) return NotFound("Contact not found");
                
                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving contact with ID {ContactId}.", id);
                return StatusCode(500, "An error occurred while retrieving the contact.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            try
            {
                var createdContact = await _contactService.CreateContact(contact);
                return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new contact.");
                return StatusCode(500, "An error occurred while creating the contact.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(int id, Contact request)
        {
            try
            {
                var updatedContact = await _contactService.UpdateContact(id, request);
                if (updatedContact is null) return NotFound("Contact not found");

                return Ok(updatedContact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating contact with ID {ContactId}.", id);
                return StatusCode(500, "An error occurred while updating the contact.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            try
            {
                var success = await _contactService.DeleteContact(id);
                if (!success) return NotFound("Contact not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting contact with ID {ContactId}.", id);
                return StatusCode(500, "An error occurred while deleting the contact.");
            }
        }
    }
}
