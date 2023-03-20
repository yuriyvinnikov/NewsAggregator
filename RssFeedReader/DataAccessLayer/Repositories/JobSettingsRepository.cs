using RssFeedReader.DataAccessLayer.Entities;
using RssFeedReader.DataAccessLayer.Contracts;

namespace RssFeedReader.DataAccessLayer.Repositories
{
    public class JobSettingsRepository : BaseEFRepository<JobSettings>, IJobSettingsRepository
    {
        public JobSettingsRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
