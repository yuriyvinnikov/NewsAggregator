namespace DataAccessLayer
{
    public class NewsAgency : BaseEntity
    {
        public string Name { get; set; }

        public JobSettings JobSettings { get; set; }
    }
}
