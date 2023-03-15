namespace DataAccessLayer.Contracts
{
    public interface IAdoNetRepository
    {
        public Task CreateTableForNewsAgensy(string tableName, int newsAgencyId);
        public Task<bool> CheckIfTableExists(string tableName);
    }
}
