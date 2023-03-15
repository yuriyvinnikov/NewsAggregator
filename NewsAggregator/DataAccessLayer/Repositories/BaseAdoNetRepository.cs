using DataAccessLayer.Entities;
using DataAccessLayer.Contracts;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class BaseAdoNetRepository : IRepository<BaseEntity>, IAdoNetRepository
    {
        private readonly AdoNetDbConfiguration _configuration;

        public BaseAdoNetRepository(AdoNetDbConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<BaseEntity> AddAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfEntityExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckIfTableExists(string tableName)
        {
            int result = default;
            var resultName = "Count";
            var parameter = "@TableName";

            string query = $"SELECT COUNT(*) as '{resultName}' FROM sys.tables WHERE name like('%{parameter}%');";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue(parameter, tableName);

            try
            {
                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result = (int)reader[resultName];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return result > 0;
        }

        public async Task CreateTableForNewsAgensy(string tableName, int newsAgencyId)
        {
            throw new NotImplementedException();

            //const string query =
            //@"CREATE TABLE dbo.Products
            //    (
            //        ID int IDENTITY(1,1) NOT NULL,
            //        Name nvarchar(50) NULL,
            //        Price nvarchar(50) NULL,
            //        Date datetime NULL,
            //        CONSTRAINT pk_id PRIMARY KEY (ID)
            //    );";

            //using var connection = new SqlConnection(_configuration.ConnectionString);
            //using SqlCommand cmd = new(query, connection);
            //cmd.CommandType = CommandType.Text;

            //try
            //{
            //    connection.Open();
            //    await cmd.ExecuteNonQueryAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
