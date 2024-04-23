using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.JobListing;

namespace OnlyTools.Controllers
{
    [Authorize]
    public class JobListingController : BaseController
    {
       private readonly IJobListingServices _services;
        private readonly ICategoriesServices _categoryServices;
        public JobListingController(IJobListingServices services, ICategoriesServices categoryServices)
        {
            _services = services;
            _categoryServices = categoryServices;

        }

        public async Task<IActionResult> All(int page = 1, int pageSize = 5)
        {
            var jobs = await _services.GetAllJobListingsAsync();
            var (paginatedJobs, totalPages, hasPreviousPage, hasNextPage) = await Paginate(jobs, page, pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = hasPreviousPage;
            ViewBag.HasNextPage = hasNextPage;

            return View(paginatedJobs);
        }


        [HttpGet]
        public async Task<IActionResult> AddJob()
        {
            var job = new JobListingUploadModel();
            job.Categories = await _categoryServices.GetJobsCategoriesAsync();
            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobListingUploadModel job)
        {
            Guid userId = GetUserId();
            job.PosterId = userId;
            await _services.AddNewJobAsync(job, userId);
            return View(job);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            JobListingDetailModel jobDetails = await _services.GetSpecificJobByIdAsync(id);
            if (jobDetails == null)
            {
                return NotFound();
            }
            return View(jobDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var job = await _services.GetSpecificJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            var jobM = new JobListingUploadModel
            {
                Title = job.Title,
                Description = job.Description,
                Price = job.Price,
                IsServiceOffered = job.IsServiceOffered
            };
            jobM.Categories = await _categoryServices.GetJobsCategoriesAsync();
            return View(jobM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobListingUploadModel job)
        {
            await _services.UpdateJobAsync(id, job);
            return RedirectToAction("Details", "JobListing", new { id = job.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteJobAsync(id);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyJobs(int page = 1, int pageSize = 5)
        {
            Guid myId = GetUserId();
            var job = await _services.GetMyJobsAsync(myId);
            var (paginatedJobs, totalPages, hasPreviousPage, hasNextPage) = await Paginate(job, page, pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = hasPreviousPage;
            ViewBag.HasNextPage = hasNextPage;

            return View(paginatedJobs);
        }

    }
}
