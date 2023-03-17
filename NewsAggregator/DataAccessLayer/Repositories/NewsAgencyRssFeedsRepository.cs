using DataAccessLayer.Entities;
using DataAccessLayer.Contracts;

namespace DataAccessLayer.Repositories
{
    public class NewsAgencyRssFeedsRepository : BaseEFRepository<NewsAgencyRssFeed>, INewsAgencyRssFeedsRepository
    {
        public NewsAgencyRssFeedsRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
