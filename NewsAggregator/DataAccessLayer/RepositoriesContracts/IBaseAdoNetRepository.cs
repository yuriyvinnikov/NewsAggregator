namespace DataAccessLayer.RepositoriesContracts
{
    public interface IBaseAdoNetRepository
    {
        public Task CreateTable(string tableName);
        public Task<bool> CheckIfTableExists(string tableName);
    }
}
