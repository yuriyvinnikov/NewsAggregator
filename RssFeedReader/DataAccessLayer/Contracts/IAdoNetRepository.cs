namespace RssFeedReader.DataAccessLayer.Contracts
{
    public interface IAdoNetRepository
    {
        public Task CreateTableForNewsAgencyAsync(string tableName);
        public Task<bool> CheckIfTableExistsAsync(string tableName);
    }
}
