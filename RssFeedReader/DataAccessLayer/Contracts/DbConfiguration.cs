namespace RssFeedReader.DataAccessLayer.Contracts
{
    public abstract class DbConfiguration
    {
        public abstract string ConnectionString { get; }
    }
}
