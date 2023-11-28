using ContactsApi.Data;
using ContactsApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ContactsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _dataContext.Contacts.ToListAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById( int id)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if ( contact is null)
            {
                return NotFound("Contact not found");
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            _dataContext.Contacts.Add(contact);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Contacts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact)
        {
            var dbContact = await _dataContext.Contacts.FindAsync(contact.Id);
            if (contact is null)
            {
                return NotFound("Contact not found");
            }
            dbContact.Fullname = contact.Fullname;
            dbContact.Address = contact.Address;
            dbContact.MobilePhoneNumber = contact.MobilePhoneNumber;
            dbContact.Email = contact.Email;
            dbContact.Firstname = contact.Firstname;
            dbContact.Lastname = contact.Lastname;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Contacts.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact is null)
            {
                return NotFound("Contact not found");
            }
            _dataContext.Contacts.Remove(contact);

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Contacts.ToListAsync());
        }
    }
}
