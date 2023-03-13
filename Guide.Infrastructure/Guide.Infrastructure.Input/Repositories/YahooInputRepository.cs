using System.Data;
using Dapper;
using Guide.Application.Input.Interfaces;
using Guide.Domain.Entities;
using Guide.Infrastructure.Input.Queries;
using Guide.Infrastructure.Shared.Factory;

namespace Guide.Infrastructure.Input.Repositories
{
    public class YahooInputRepository : IYahooInputRepository
    {
        private readonly IDbConnection _connection; 

        public YahooInputRepository(SqlFactory factory)
        {
            _connection = factory.GetSqlConnection();
        }
        public void InsertYahooFinance(YahooFinanceEntity dto)
        {
            _connection.Open();

            try
            {
                var query = new QueryInput().InsertABEV3Query(dto);
                _connection.Execute(query.Query, query.Parameters);
            }
            catch
            {
                throw new Exception("Erro ao inserir dados.");
            }

            _connection.Close();
        }
    }
}