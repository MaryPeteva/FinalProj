using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.Category;
using OnlyTools.Core.Models.JobListing;
using OnlyTools.Core.Models.Tool;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Core.Services
{
    public class JobListingServices:IJobListingServices
    {
        private readonly OnlyToolsDbContext context;

        public JobListingServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewJobAsync(JobListingUploadModel job, Guid userId)
        {
            JobListingCategory cat = await context.JobListingCategories.FindAsync(job.CategoryId);
            var user = await context.Users.FindAsync(userId);
            var jobListing = new JobListing { 
                Title = job.Title,
                Description = job.Description,
                PosterId = userId,
                Poster = user,
                Price = job.Price,
                CategoryId = job.CategoryId,
                Category = cat,
                IsServiceOffered = job.IsServiceOffered,

            };

            await context.JobListings.AddAsync(jobListing);
            await context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int id)
        {
            JobListing job = await context.JobListings.FindAsync(id);
            context.Remove(job);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobListingAllModel>> GetAllJobListingsAsync()
        {
           return await context.JobListings
                .Select(j => new JobListingAllModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    IsServiceOffered = j.IsServiceOffered,
                    Category = new JobListingCategory()
                    {
                        Id = j.CategoryId,
                        Name = j.Category.Name
                    },
                    Posted = j.Posted,
                    PosterId = j.PosterId,
                    Poster = j.Poster
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<JobListingAllModel>> GetMyJobsAsync(Guid myId)
        {
            return await context.JobListings
                .Where(j => j.PosterId == myId)
                .Select(j => new JobListingAllModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    IsServiceOffered = j.IsServiceOffered,
                    Category = new JobListingCategory()
                    {
                        Id = j.CategoryId,
                        Name = j.Category.Name
                    },
                    Posted = j.Posted,
                    PosterId = j.PosterId,
                    Poster = j.Poster
                })
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<JobListingDetailModel> GetSpecificJobByIdAsync(int id)
        {
            var job = await context.JobListings.FindAsync(id);
            var cat = await context.JobListingCategories.FindAsync(job.CategoryId);
            JobListingDetailModel jobReturn = new JobListingDetailModel() { 
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                PosterId = job.PosterId,
                Poster = job.Poster,
                Price = job.Price,
                CategoryId = job.CategoryId,
                Category = new CategoryModel() { 
                    Id = cat.Id,
                    Name = cat.Name
                },
                Posted = job.Posted,
            };

            return jobReturn;
        }

        public async Task UpdateJobAsync(int id, JobListingUploadModel job)
        {
            var jobToUpdate = await context.JobListings.FindAsync(job.Id);
            var cat = await context.JobListingCategories.FindAsync(job.CategoryId);
            if (jobToUpdate == null) 
            {
                throw new NullReferenceException("No job listing found!");
            }
            jobToUpdate.Title = job.Title;
            jobToUpdate.Description = job.Description;
            jobToUpdate.Price = job.Price;
            jobToUpdate.Category = cat;
            jobToUpdate.IsServiceOffered = job.IsServiceOffered;

            await context.SaveChangesAsync();

        }
    }
}
