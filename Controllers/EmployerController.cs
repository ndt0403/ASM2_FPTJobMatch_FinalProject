using FPT_JOBPORTAL.Models;
using FPT_JOBPORTAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPT_JOBPORTAL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> employerList = _unitOfWork.ApplicationUserRepository.GetAll(u => u.Role == "Employer").ToList();
            return View(employerList);
        }

        // Suspend action to display suspend confirmation
        /*public IActionResult Suspend(string id)
        {
            var employer = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (employer == null)
            {
                return NotFound();
            }
            return View(employer);
        }

        // POST: Employer/Suspend
        [HttpPost, ActionName("Suspend")]
        [ValidateAntiForgeryToken]
        public IActionResult SuspendPost(string id)
        {
            var employer = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (employer == null)
            {
                return NotFound();
            }

            // Implement suspension logic here
            employer.IsSuspended = true; // Assuming you have a property like IsSuspended in your ApplicationUser model
            _unitOfWork.ApplicationUserRepository.Update(employer);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }*/
        public IActionResult Delete(string id)
        {
            var employer = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (employer == null)
            {
                return NotFound();
            }
            return View(employer);
        }

        // POST: Employer/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string id)
        {
            var user = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _unitOfWork.ApplicationUserRepository.Delete(user);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
