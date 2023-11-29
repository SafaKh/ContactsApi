using ContactsApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ContactsApi.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            // Regex pour valider le format de l'email
            var emailRegex = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            var match = Regex.Match(contact.Email, emailRegex);

            if (!match.Success)
            {
                throw new ArgumentException("The email format is invalid.");
            }
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact?> UpdateContact(int id, Contact updatedContact)
        {
            var existingContact = await _context.Contacts.FindAsync(id);
            if (existingContact is null)
            {
                return null;
            }

            existingContact.Fullname = updatedContact.Fullname;
            existingContact.Address = updatedContact.Address;
            existingContact.MobilePhoneNumber = updatedContact.MobilePhoneNumber;
            existingContact.Email = updatedContact.Email;
            existingContact.Firstname = updatedContact.Firstname;
            existingContact.Lastname = updatedContact.Lastname;


            await _context.SaveChangesAsync();
            return existingContact;
        }
    }
}
