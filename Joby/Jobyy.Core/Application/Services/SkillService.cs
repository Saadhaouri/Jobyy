using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public SkillService(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public IEnumerable<SkillDto> GetSkills()
    {
        var skills = _skillRepository.GetSkills();
        return _mapper.Map<IEnumerable<SkillDto>>(skills);
    }

    public SkillDto GetSkillById(string skillId)
    {
        var skill = _skillRepository.GetSkillById(skillId);
        return _mapper.Map<SkillDto>(skill);
    }

    public void AddSkill(SkillDto skill)
    {
        var skillModel = _mapper.Map<Skill>(skill);
        // You can perform additional business logic/validation here before saving
        _skillRepository.InsertSkill(skillModel);
        _skillRepository.Save();
    }

    public void UpdateSkill(SkillDto skill)
    {
        var skillModel = _mapper.Map<Skill>(skill);
        // You can perform additional business logic/validation here before updating
        _skillRepository.UpdateSkill(skillModel);
        _skillRepository.Save();
    }

    public void DeleteSkill(string skillId)
    {
        // You can perform additional business logic/validation here before deleting
        _skillRepository.DeleteSkill(skillId);
        _skillRepository.Save();
    }
}
