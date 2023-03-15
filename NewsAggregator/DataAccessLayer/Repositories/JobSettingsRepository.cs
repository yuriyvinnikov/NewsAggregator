using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;

namespace DataAccessLayer.Repositories
{
    public class JobSettingsRepository : BaseEFRepository<JobSettings>, IJobSettingsRepository
    {
        public JobSettingsRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
