namespace ContactsApi.Services.ContactService
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact?> GetContactById(int id);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact?> UpdateContact(int id, Contact request);
        Task<bool> DeleteContact(int id);
    }
}
