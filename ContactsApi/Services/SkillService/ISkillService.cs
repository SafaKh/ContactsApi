namespace ContactsApi.Services.SkillService
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkill();
        Task<Skill?> GetSkillById(int id);
        Task<Skill> CreateSkill(Skill contact);
        Task<Skill?> UpdateSkill(int id, Skill request);
        Task<bool> DeleteSkill(int id);
    }
}
