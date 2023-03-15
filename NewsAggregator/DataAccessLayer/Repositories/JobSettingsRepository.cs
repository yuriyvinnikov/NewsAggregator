using DataAccessLayer.Entities;
using DataAccessLayer.Contracts;

namespace DataAccessLayer.Repositories
{
    public class JobSettingsRepository : BaseEFRepository<JobSettings>, IJobSettingsRepository
    {
        public JobSettingsRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
