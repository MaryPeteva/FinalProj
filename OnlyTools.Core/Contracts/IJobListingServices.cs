
using OnlyTools.Core.Models.JobListing;

namespace OnlyTools.Core.Contracts
{
    public interface IJobListingServices
    {
        Task AddNewJobAsync(JobListingUploadModel job, Guid userId);
        Task DeleteJobAsync(int id);
        Task<IEnumerable<JobListingAllModel>> GetAllJobListingsAsync();
        Task<IEnumerable<JobListingAllModel>> GetMyJobsAsync(Guid myId);
        Task<JobListingDetailModel> GetSpecificJobByIdAsync(int id);
        Task UpdateJobAsync(int id, JobListingUploadModel job);
    }
}
