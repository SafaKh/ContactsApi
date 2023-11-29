
using ContactsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Services.SkillService
{
    public class SkillService : ISkillService
    {
        private readonly DataContext _context;
        public SkillService(DataContext context)
        {
            _context = context;
        }

        public Task<Skill> CreateSkill(Skill contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSkill(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Skill>> GetAllSkill()
        {
            return await _context.Skills
                .Include(c=> c.Contacts).ToListAsync();
        }

        public async Task<Skill?> GetSkillById(int id)
        {
            return await _context.Skills.Include(c => c.Contacts).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Skill?> UpdateSkill(int id, Skill request)
        {
            throw new NotImplementedException();
        }
    }
}
