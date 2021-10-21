using System;
using System.Threading.Tasks;
using CustomerDataService.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using static Dapper.SqlMapper;

namespace CustomerDataService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _awsMySqlConnectionString;
        private readonly ILogger<ContactRepository> _logger;

        public ContactRepository(IConfiguration config, ILogger<ContactRepository> logger)
        {
            _awsMySqlConnectionString = config.GetConnectionString("awsDatabase");
            _logger = logger;
        }

        /// <summary>
        ///     Returns a contact given a phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number used to search for a contact.</param>
        /// <returns></returns>
        public async Task<ContactEntity> GetContactAsync(string phoneNumber)
        {
            try
            {
                await using var connection = new MySqlConnection(_awsMySqlConnectionString);

                var query = "SELECT * FROM sys.Contact WHERE PhoneNumber=@phoneNumber";

                var result = await connection.QueryFirstOrDefaultAsync<ContactEntity>(query, new { phoneNumber });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to retrieve contact {phoneNumber}");

                throw;
            }
        }


        public async Task<int> postContactAsync(string FirstNamex, string LastNamex, string PhoneNumberx, string Emailx)
        {
            try
            {
                await using var connection = new MySqlConnection(_awsMySqlConnectionString);

                MySqlCommand cmd = new MySqlCommand("insert into sys.Contact (FirstName , LastName , Email , PhoneNumber) values ('FirstNamex' ,'LastNamex','Emailx','PhoneNumberx')", connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                var result = 1;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create contact object");

                throw;
            }
        }

    }
}