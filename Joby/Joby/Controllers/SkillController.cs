using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.ViewModel;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Web1.ViewModel;


[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;
    private readonly IMapper _mapper;

    public SkillController(ISkillService skillService, IMapper mapper)
    {
        _skillService = skillService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetSkills()
    {
        var skillsDto = _skillService.GetSkills();
        var skillsViewModel = _mapper.Map<IEnumerable<SkillViewModel>>(skillsDto);
        return Ok(skillsViewModel);
    }

    [HttpGet("{skillId}")]
    public IActionResult GetSkillById(string skillId)
    {
        var skillDto = _skillService.GetSkillById(skillId);

        if (skillDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        var skillViewModel = _mapper.Map<SkillViewModel>(skillDto);
        return Ok(skillViewModel);
    }

    [HttpPost]
    public IActionResult AddSkill([FromBody] SkillViewModel skillViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var skillDto = _mapper.Map<SkillDto>(skillViewModel);
        _skillService.AddSkill(skillDto);

        return Ok("Skill add Succ ");
    }

    [HttpPut("{skillId}")]
    public IActionResult UpdateSkill(string skillId, [FromBody] SkillViewModel skillViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingSkillDto = _skillService.GetSkillById(skillId);

        if (existingSkillDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _mapper.Map(skillViewModel, existingSkillDto);
        _skillService.UpdateSkill(existingSkillDto);

        return NoContent();
    }

    [HttpDelete("{skillId}")]
    public IActionResult DeleteSkill(string skillId)
    {
        var existingSkillDto = _skillService.GetSkillById(skillId);

        if (existingSkillDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _skillService.DeleteSkill(skillId);

        return NoContent();
    }
}
