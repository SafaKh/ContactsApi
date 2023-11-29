
using ContactsApi.Data;
using ContactsApi.DTOs;
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

        public async Task<Skill> CreateSkill(SkillDto skillDto)
        {
            if (skillDto == null)
            {
                throw new ArgumentNullException(nameof(skillDto));
            }

            var skill = new Skill
            {
                Id = skillDto.Id,
                Level = skillDto.Level,
                Name = skillDto.Name
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
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
