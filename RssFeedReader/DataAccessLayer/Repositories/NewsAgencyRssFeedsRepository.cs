using RssFeedReader.DataAccessLayer.Entities;
using RssFeedReader.DataAccessLayer.Contracts;

namespace RssFeedReader.DataAccessLayer.Repositories
{
    public class NewsAgencyRssFeedsRepository : BaseEFRepository<NewsAgencyRssFeed>, INewsAgencyRssFeedsRepository
    {
        public NewsAgencyRssFeedsRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
