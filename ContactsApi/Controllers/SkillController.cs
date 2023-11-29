using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly ILogger<SkillController> _logger;
        public SkillController(ISkillService skillService, ILogger<SkillController> logger)
        {
            _skillService = skillService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetAllSkill()
        {
            try
            {
                var skills = await _skillService.GetAllSkill();
                return Ok(skills);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving skills.");
                return StatusCode(500, "An error occurred while retrieving skills.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSkillById(int id)
        {
            try
            {
                var skill = await _skillService.GetSkillById(id);
                if (skill is null) return NotFound("Skill not found");

                return Ok(skill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving skill with ID {SkillId}.", id);
                return StatusCode(500, "An error occurred while retrieving the skill.");
            }
        }
    }
}
