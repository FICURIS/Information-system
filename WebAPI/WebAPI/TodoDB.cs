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
}