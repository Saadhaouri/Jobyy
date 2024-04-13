using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

public class SkillRepository : ISkillRepository, IDisposable
{
    private readonly JobyDbContext _context;

    public SkillRepository(JobyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Skill> GetSkills()
    {
        return _context.Skills.ToList();
    }

    public Skill GetSkillById(string skillId)
    {
        var skill = _context.Skills.Find( skillId);
        if (skill == null )
        {
            return null; // or any other message you prefer

        }
        return skill ;
    }

    public void InsertSkill(Skill skill)
    {
        // Assign a new string if one is not provided
       

        _context.Skills.Add(skill);
    }

    public void DeleteSkill(string skillId)
    {
        Skill skill = _context.Skills.Find(skillId);
        if (skill != null)
        {
            _context.Skills.Remove(skill);
        }
    }

    public void UpdateSkill(Skill skill)
    {
        _context.Entry(skill).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
