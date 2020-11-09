using DnD_Board.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DnD_Board.Data.Contexts
{
    public class EfDbContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BoardUser> BoardUsers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TaskAssignee> TaskAssignees { get; set; }

        public DbSet<TaskAction> TaskActions { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<TaskLabel> TaskLabels { get; set; }

        public EfDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}