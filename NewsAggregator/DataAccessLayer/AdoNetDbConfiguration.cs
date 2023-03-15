using DataAccessLayer.Contracts;

namespace DataAccessLayer
{
    public class AdoNetDbConfiguration : DbConfiguration
    {
        public AdoNetDbConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override string ConnectionString { get; }
    }
}
