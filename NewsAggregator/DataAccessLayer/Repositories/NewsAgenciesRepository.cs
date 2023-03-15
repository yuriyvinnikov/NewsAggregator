using DataAccessLayer.Entities;
using DataAccessLayer.Contracts;

namespace DataAccessLayer.Repositories
{
    public class NewsAgenciesRepository : BaseEFRepository<NewsAgency>, INewsAgenciesRepository
    {
        public NewsAgenciesRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
