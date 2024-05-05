using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FPT_JOBPORTAL.Models;

namespace FPT_JOBPORTAL.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CategoryModel> CategoryModel { get; set; }
    public DbSet<JobModel> JobModel { get; set; }
    public DbSet<Application> Application { get; set; }
    
}
