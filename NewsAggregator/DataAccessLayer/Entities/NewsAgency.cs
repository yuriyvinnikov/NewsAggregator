namespace DataAccessLayer.Entities;

public class NewsAgency : BaseEntity
{
    public string Name { get; set; }

    public JobSettings JobSettings { get; set; }
}
