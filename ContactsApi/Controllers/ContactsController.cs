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

        /// <summary>
        /// Retrieves a list of all Contacts.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves a specific contact by unique ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>A newly created contact object</returns>
        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
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

        /// <summary>
        /// Update a specific 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, Contact request)
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

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
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
