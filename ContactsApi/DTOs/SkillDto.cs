namespace ContactsApi.DTOs
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } // Assumes level of expertise is numerical
    }
}
