using RssFeedReader.DataAccessLayer.Contracts;
using RssFeedReader.DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RssFeedReader.DataAccessLayer.Repositories
{
    public class BaseAdoNetRepository : IAdoNetRepository
    {
        private readonly AdoNetDbConfiguration _configuration;

        public BaseAdoNetRepository(AdoNetDbConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<XmlNews> AddAsync(XmlNews entity, string tableName)
        {
            string query = $"INSERT INTO dbo.{tableName} VALUES (@NewsStorageMetaDataId, @Xml, @CreatedBy, @UpdatedBy, @CreatedAt, @UpdatedAt);";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@NewsStorageMetaDataId", entity.NewsStorageMetaDataId);
            cmd.Parameters.AddWithValue("@Xml", entity.Xml);
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", entity.UpdatedBy);
            cmd.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt);
            cmd.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedBy);

            try
            {
                connection.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return new XmlNews();
        }

        public async Task<bool> CheckIfEntityExistsAsync(int id, string tableName)
        {
            int result = default;
            var resultName = "Count";
            var parameter = "@Id";

            string query = $"SELECT COUNT(*) as '{resultName}' FROM dbo.{tableName} WHERE Id = {parameter};";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue(parameter, id);

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

        public async Task<bool> CheckIfTableExistsAsync(string tableName)
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

        public async Task CreateTableForNewsAgencyAsync(string tableName)
        {
            string query = $@"CREATE TABLE dbo.{tableName}
                (
                    Id int IDENTITY(1,1) NOT NULL,
                    NewsStorageMetaDataId int NULL,
                    Xml nvarchar(max) NULL,
                    CreatedBy nvarchar(50) NULL,
                    UpdatedBy nvarchar(50) NULL,
                    CreatedAt datetime NULL,
                    UpdatedAt datetime NULL,
                    CONSTRAINT PK_{tableName}_Id PRIMARY KEY CLUSTERED ([Id]),
                    CONSTRAINT FK_{tableName}NewsStorageMetaDat FOREIGN KEY (NewsStorageMetaDataId)
                    REFERENCES NewsStorageMetaData (Id)
                    ON DELETE SET NULL
                    ON UPDATE SET NULL
                );";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;

            try
            {
                connection.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<XmlNews>> GetAllAsync(string tableName)
        {
            List<XmlNews> result;

            string query = $"SELECT Id, NewsStorageMetaDataId, FROM dbo.{tableName};";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;

            try
            {
                result = new List<XmlNews>();

                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    XmlNews entity = new()
                    {
                        Id = (int)reader["@Id"],
                        NewsStorageMetaDataId = (int)reader["@NewsStorageMetaDataId"],
                        Xml = reader["@Xml"].ToString()
                    };

                    result.Add(entity);
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

            return result;
        }

        public async Task<XmlNews> GetByIdAsync(int id, string tableName)
        {
            XmlNews result;

            var parameter = "@Id";
            
            string query = $"SELECT Id, NewsStorageMetaDataId, FROM dbo.{tableName} WHERE Id = {parameter};";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue(parameter, id);

            try
            {
                result = new XmlNews();

                connection.Open();

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Id = (int)reader["@Id"];
                    result.NewsStorageMetaDataId = (int)reader["@NewsStorageMetaDataId"];
                    result.Xml = reader["@Xml"].ToString();
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

            return result;
        }

        public async Task UpdateAsync(string tableName, XmlNews entity)
        {
            string query = $@"UDATE TABLE dbo.{tableName} 
                                SET
                                Xml = @Xml, UpdatedBy = @UpdatedBy, UpdatedAt = @UpdatedAt
                              WHERE Id = @Id";

            using var connection = new SqlConnection(_configuration.ConnectionString);

            using SqlCommand cmd = new(query, connection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Xml", entity.Xml);
            cmd.Parameters.AddWithValue("@UpdatedBy", entity.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@Id", entity.Id);

            try
            {
                connection.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
