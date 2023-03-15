using DataAccessLayer.Entities;
using DataAccessLayer.RepositoriesContracts;

namespace DataAccessLayer.Repositories
{
    public class NewsAgenciesRepository : BaseEFRepository<NewsAgency>, INewsAgenciesRepository
    {
        public NewsAgenciesRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
