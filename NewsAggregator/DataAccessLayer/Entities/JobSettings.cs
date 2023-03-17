namespace DataAccessLayer.Entities;

public class JobSettings : BaseEntity
{
    public string RssFeedUrl { get; set; }

    public string CronExpression { get; set; }

    public bool StartAutomatically { get; set; }


    public int NewsAgencyRssFeedId { get; set; }
    public virtual NewsAgencyRssFeed NewsAgencyRssFeed { get; set; }
}