namespace ContactsApi.Services.ContactService
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact?> GetContactById(int id);
        Task<List<Contact>> CreateContact(Contact contact);
        Task<List<Contact>?> UpdateContact(int id, Contact request);
        Task<List<Contact>?> DeleteContact(int id);
    }
}
