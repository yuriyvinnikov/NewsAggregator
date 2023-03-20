using RssFeedReader.DataAccessLayer.Contracts;
using RssFeedReader.DataAccessLayer.Entities;

namespace RssFeedReader.DataAccessLayer.Repositories
{
    public class NewsStorageMetaDataRepository : BaseEFRepository<NewsStorageMetaData>, INewsStorageMetaDataRepository
    {
        public NewsStorageMetaDataRepository(RssFeedReaderDbContext context) : base(context)
        {
        }
    }
}
