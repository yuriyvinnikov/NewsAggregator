namespace DataAccessLayer.Entities;

public class NewsAgencyRssFeed : BaseEntity
{
    public string Name { get; set; }

    public int JobSettingsId { get; set; }
    public virtual JobSettings JobSettings { get; set; }

    public int NewsStorageMetaDataId { get; set; }
    public virtual NewsStorageMetaData NewsStorageMetaData { get; set; }
}
