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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 1, Name = "Back-End Developer", Description = "A Back End Developer is responsible for server-side application logic and integration of the work front-end developers do." },
            new CategoryModel { Id = 2, Name = "Front-End Developer", Description = "A Front End Developer is focused on the user interface and user experience of a website or application." },
            new CategoryModel { Id = 3, Name = "Full Stack Developer", Description = "A Full Stack Developer is capable of working on both the front-end and back-end portions of an application." },
            new CategoryModel { Id = 4, Name = "Mobile Apps Developer", Description = "A Mobile Apps Developer is specialized in creating applications for mobile devices, such as smartphones and tablets." },
            new CategoryModel { Id = 5, Name = "Product Manager", Description = "A Product Manager is responsible for the strategy, roadmap, and feature definition of a product." },
            new CategoryModel { Id = 6, Name = "Python Developer", Description = "A Python Developer uses the Python programming language for developing software solutions." },
            new CategoryModel { Id = 7, Name = "System Administrator", Description = "A System Administrator manages and maintains the operations of computer systems and networks." },
            new CategoryModel { Id = 8, Name = "Tester", Description = "A Tester tests software to ensure it meets requirements and is free of bugs and defects." },
            new CategoryModel { Id = 9, Name = "C++ Developer", Description = "A C++ Developer uses the C++ programming language for developing software solutions." },
            new CategoryModel { Id = 10, Name = "Software Architect", Description = "A Software Architect designs and creates the overall structure of a software system." }
        );
        modelBuilder.Entity<JobModel>().HasData(
            new JobModel
            {
                Id = 1,
                NameJob = "Mobile Apps Developer",
                CategoryId = 4,
                DescriptionJob = "Join our mobile development team to create innovative and user-friendly mobile applications for iOS and Android platforms.",
                Company = "MegaTechnology",
                DatePost = DateTime.UtcNow.Date.AddDays(-7),
                Salary = 95000,
                Requirement = "Experience in mobile app development using Swift or Kotlin, familiarity with mobile UI/UX principles, ability to adapt to new technologies.",
            },
            new JobModel
            {
                Id = 2,
                NameJob = "Full Stack Developer",
                CategoryId = 3,
                DescriptionJob = "We're seeking a Full Stack Developer to work on both front-end and back-end components of our applications.",
                Company = "MegaTechnology",
                DatePost = DateTime.UtcNow.Date.AddDays(-7),
                Salary = 95000,
                Requirement = "Proficiency in both front-end and back-end technologies, experience with frameworks such as React and Node.js, ability to work in a fast-paced environment.",
            }, new JobModel
            {
                Id = 3,
                NameJob = "Front End Developer Intern",
                CategoryId = 2,
                DescriptionJob = "Exciting opportunity for a Front End Developer Intern to gain hands-on experience in building user interfaces and enhancing user experiences.",
                Company = "MegaTechnology",
                DatePost = DateTime.UtcNow.Date.AddDays(-7),
                Salary = 25000,
                Requirement = "Basic understanding of HTML, CSS, and JavaScript, eager to learn and contribute to front-end development projects.",
            }, new JobModel
            {
                Id = 4,
                NameJob = "Senior Back End Developer",
                CategoryId = 1,
                DescriptionJob = "Join our team as a Senior Back End Developer to lead server-side application logic and integration efforts.",
                Company = "MegaTechnology",
                DatePost = DateTime.UtcNow.Date.AddDays(-7),
                Salary = 95000,
                Requirement = "5+ years of experience in back-end development, proficiency in relevant technologies such as Node.js, Python, or Java, strong understanding of databases and API design.",
            }, new JobModel
            {
                Id = 5,
                NameJob = "Product Manager",
                CategoryId = 5,
                DescriptionJob = "We're looking for a Product Manager to drive the strategy and development of our product offerings.",
                Company = "MegaTechnology",
                DatePost = DateTime.UtcNow.Date.AddDays(-7),
                Salary = 110000,
                Requirement = "Strong leadership and communication skills, experience in product management, ability to prioritize and manage multiple projects.",
            }
        );
    }
}