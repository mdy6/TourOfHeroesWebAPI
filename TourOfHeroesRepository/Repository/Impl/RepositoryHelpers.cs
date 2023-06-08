using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using TourOfHeroesCore.Configuration;

namespace TourOfHeroesRepository.Repository.Impl
{
    public static class RepositoryHelpers
    {
        public static SqlConnection GetConnection(this IOptions<DatabaseInfoOptions> options) => new SqlConnection(options.Value.ConnectionString);
        public static string GetSqlQueryContent(this IOptions<DatabaseInfoOptions> options, string sqlFileName)
        {
            return File.ReadAllText($"{options.Value.SqlScriptPath}\\{sqlFileName}");
        }
    }
}