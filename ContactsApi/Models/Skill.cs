namespace ContactsApi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  
        public int Level { get; set; } // Assumes level of expertise is numerical
        public List<Contact>? Contacts { get; set; } = null; 
    }
}
