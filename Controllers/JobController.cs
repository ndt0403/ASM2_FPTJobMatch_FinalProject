using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPT_JOBPORTAL;
using FPT_JOBPORTAL.Data;
using Microsoft.AspNetCore.Authorization;

namespace FPT_JOBPORTAL.Controllers
{
    [Authorize(Roles = "Admin, Employer, Job Seeker")]

    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobModel.Include(j => j.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryModel, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameJob,CategoryId,DescriptionJob,Company,DatePost,Salary,Requirement")] JobModel jobModel)
        {
            if (ModelState.IsValid)
            {
                var category = await _context.CategoryModel.FindAsync(jobModel.CategoryId);

                if (category.Status == CategoryStatus.Pending)
                {
                    ModelState.AddModelError(string.Empty, "Cannot create job for a category with pending status.");
                    ViewData["CategoryId"] = new SelectList(_context.CategoryModel, "Id", "Name", jobModel.CategoryId);
                    return View(jobModel);
                }

                jobModel.DatePost = DateTime.Now;
                _context.Add(jobModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryModel, "Id", "Name", jobModel.CategoryId);
            return View(jobModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryModel, "Id", "Name", jobModel.CategoryId);
            return View(jobModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameJob,CategoryId,DescriptionJob,Company,DatePost,Salary,Requirement")] JobModel jobModel)
        {
            if (id != jobModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jobModel.DatePost = DateTime.Now;
                    _context.Update(jobModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobModelExists(jobModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryModel, "Id", "Name", jobModel.CategoryId);
            return View(jobModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel != null)
            {
                _context.JobModel.Remove(jobModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobModelExists(int id)
        {
            return _context.JobModel.Any(e => e.Id == id);
        }
    }
}
