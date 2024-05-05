using FPT_JOBPORTAL.Models;

namespace FPT_JOBPORTAL.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
    }
}
