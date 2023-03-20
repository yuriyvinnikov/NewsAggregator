namespace RssFeedReader.DataAccessLayer.Entities
{
    public class NewsStorageMetaData : BaseEntity
    {
        public string TableName { get; set; }

        public int NewsAgencyRssFeedId { get; set; }
        public NewsAgencyRssFeed NewsAgencyRssFeed { get; set; }
    }
}
