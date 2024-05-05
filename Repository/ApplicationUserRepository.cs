﻿using FPT_JOBPORTAL.Data;
using FPT_JOBPORTAL.Models;
using FPT_JOBPORTAL.Repository.IRepository;

namespace FPT_JOBPORTAL.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }
    }
}
