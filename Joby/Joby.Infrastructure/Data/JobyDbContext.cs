using Joby.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Joby.Infrastructure.Data
{
    public class JobyDbContext : IdentityDbContext
    {

        public JobyDbContext(DbContextOptions<JobyDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Opportunity> Opportunity { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<React> Reacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(x => x.Contact, navigation =>
            {
                navigation.ToJson();
            });
            modelBuilder.Entity<User>().OwnsMany(t => t.Educations, navigation =>
            {
                navigation.ToJson();
            });
            modelBuilder.Entity<User>().OwnsMany(t => t.Experiences, navigation =>
            {
                navigation.ToJson();
            });

            modelBuilder.Entity<Company>().OwnsOne(z => z.Contact, navigation =>
            {
                navigation.ToJson();
            });

            //modelBuilder.Entity<UserApp>().
            //    HasOne(e => e.User).WithOne(b => b.UserApp)
            //    .HasForeignKey<User>(b => b.UserAppId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });

            modelBuilder.Entity<Skill>()
                .HasKey(skill => skill.Id);

            // Configure primary key for OpportunitySkillModel
            modelBuilder.Entity<OpportunitySkill>()
                .HasKey(os => new { os.OpportunityId, os.SkillId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
