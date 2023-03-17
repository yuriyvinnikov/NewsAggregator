using DataAccessLayer.Contracts;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class NewsStorageMetaDataRepository : BaseEFRepository<NewsStorageMetaData>, INewsStorageMetaDataRepository
    {
        public NewsStorageMetaDataRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
