using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Request> Request { get; set; }
    public DbSet<RequestStatus> RequestStatus { get; set; }
    public DbSet<UserEnrollment> UserEnrollment { get; set; }
    public DbSet<PhoneNumber> PhoneNumber { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(e => e.UserID);

            entity.Property(e => e.UserID)
                .HasColumnName("user_id");

            entity.Property(e => e.Login)
                .HasColumnName("login")
                .IsRequired();

            entity.Property(e => e.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired();

            entity.Property(e => e.Email)
                .HasColumnName("email");
        });
        modelBuilder.Entity<Course>().ToTable("courses");
        modelBuilder.Entity<Request>().ToTable("requests");
        modelBuilder.Entity<Role>().ToTable("roles");
        modelBuilder.Entity<RequestStatus>().ToTable("request_statuses");
    }
}

