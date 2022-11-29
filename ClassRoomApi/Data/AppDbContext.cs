using ClassRoomApi.Data.Configurations;
using ClassRoomApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskConfiguration = ClassRoomApi.Data.Configurations.TaskConfiguration;

namespace ClassRoomApi.Data;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
	public DbSet<Course>? Courses { get; set; }
	public DbSet<UserCourse>? UserCourses { get; set; }
	public DbSet<TaskEntity>? TaskEntities { get; set; }
	public DbSet<UserTask>? UserTasks { get; set; }
	public DbSet<TaskComment>? TaskComments { get; set; }
	public DbSet<LocalizedStringEntity>? LocalizedStringEntities { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		TaskConfiguration.Sozla(builder.Entity<TaskEntity>());

		new UserTaskConfiguration().Configure(builder.Entity<UserTask>());

		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

	}
}
