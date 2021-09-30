using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CustomerDataService.Repositories
{
	public class ContactRepository : IContactRepository
    {
		private readonly ILogger<ContactRepository> logger;
		public ContactRepository(ILogger<ContactRepository> logger) => this.logger = logger;

		public async Task<ContactEntity> GetContactAsync(string phoneNumber)
        {
			try
			{
				var connectionString = "Server=enterprise.c7ctqwx485et.us-east-1.rds.amazonaws.com;Port=3306;Database=enterprise;Uid=<username>;Pwd=<password>;";

				using var connection = new MySqlConnection(connectionString);

				var parameters = new { phoneNumber = phoneNumber };

				var query = $"SELECT * FROM sys.Contact WHERE PhoneNumber = @phoneNumber";

				return await connection.QueryFirstOrDefaultAsync<ContactEntity>(query, new { parameters });
			}
			catch (Exception ex)
			{
				logger.LogError(ex, $"Failed to retrieve contact {phoneNumber}");

				throw;
			}
		}
    }
}
