using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Cafeteria.Api.Data.Repositories
{
    public class RepositoryBase
    {
        protected IConfiguration configuration;

        internal IDbConnection Connection
        {
            get
            {
                var connect = new NpgsqlConnection(configuration["ConfigurationString"]);

                connect.Open();
                return connect;
            }
        }

    }
}
