using Microsoft.Extensions.Configuration;

namespace Cafeteria.Api.Data.Repositories
{
    public class DocesRepository : RepositoryBase
    {
        public DocesRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
    }
}
