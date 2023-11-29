using ContactsApi.DTOs;
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

        /// <summary>
        /// Retrieves a list of all skills.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves a specific skill by unique ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillById(int id)
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

        /// <summary>
        /// Creates a new skill.
        /// </summary>
        /// <param name="skillDto"></param>
        /// <returns>A newly created Skill object</returns>
        [HttpPost]
        public async Task<ActionResult<Skill>> CreateSkill(SkillDto skillDto)
        {
            try
            {
                var createdSkill = await _skillService.CreateSkill(skillDto);
                return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.Id }, createdSkill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new skill.");
                return StatusCode(500, "An error occurred while creating the skill.");
            }
        }

        /// <summary>
        /// Updates a specific skill.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> UpdateSkill(int id, SkillDto skill)
        {
            try
            {
                var updatedSkill = await _skillService.UpdateSkill(id, skill);
                if (updatedSkill is null) return NotFound("Skill not found");

                return Ok(updatedSkill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating skill with ID {SkillId}.", id);
                return StatusCode(500, "An error occurred while updating the skill.");
            }

        }

        /// <summary>
        /// Delete skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(int id) 
        {
            try 
            {
                var success = await _skillService.DeleteSkill(id);
                if (!success) return NotFound("Skill not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting Skill with ID {SkillId}.", id);
                return StatusCode(500, "An error occurred while deleting the Skill.");
            }
        }
    }
}
