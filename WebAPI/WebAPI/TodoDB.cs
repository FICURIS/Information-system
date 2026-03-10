using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestStatus> RequestStatuses { get; set; }
    public DbSet<UserEnrollment> UserEnrollments { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
}