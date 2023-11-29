using System.Text.Json.Serialization;

namespace ContactsApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public required string Fullname { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobilePhoneNumber { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Skill>? Skills { get; set; } = null;
    }
}
