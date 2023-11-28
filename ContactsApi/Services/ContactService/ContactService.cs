
using ContactsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return await _context.Contacts.ToListAsync();
        }

        public async Task<List<Contact>?> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null) return null;

            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();
            return await _context.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return contacts;
        }

        public async Task<Contact?> GetContactById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null)
            {
                return null;
            }

            return contact;
        }

        public async Task<List<Contact>?> UpdateContact(int id, Contact request)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null)
            {
                return null;
            }
            contact.Fullname = request.Fullname;
            contact.Firstname = request.Firstname;
            contact.Lastname = request.Lastname;
            contact.Email = request.Email;
            contact.Address = request.Address;
            contact.MobilePhoneNumber = request.MobilePhoneNumber;

            await _context.SaveChangesAsync();
            return await _context.Contacts.ToListAsync();
        }
    }
}
