using System;
using System.Threading.Tasks;
using CustomerDataService.Dtos;
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
        /// Returns a contact given a phone number.
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

        /// <summary>
        /// Create a contact
        /// </summary>
        /// <param name="request">Contact to create</param>
        /// <returns>Create Contact</returns>
        public async Task<ContactEntity?> CreateContactAsync(CreateContactRequest request)
        {
            try
            {
                await using var connection = new MySqlConnection(_awsMySqlConnectionString);

                var query = "INSERT INTO sys.Contact(FirstName, LastName, Email, PhoneNumber) VALUES(@firstName, @lastName, @email, @phoneNumber)";


                var result = await connection.QueryFirstOrDefaultAsync<ContactEntity>(query, new { request.FirstName, request.LastName, request.Email, request.PhoneNumber });
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create contact object");

                throw;
            }
        }
        public async Task<ContactEntity?> UpdateContactAsync(int id, string firstName, string lastName, string email, string phoneNumber)
        {
            try
            {
                await using var connection = new MySqlConnection(_awsMySqlConnectionString);

                var query = "UPDATE sys.Contact SET FirstName=@firstName, LastName=@lastName, Email=@email, PhoneNumber=@phoneNumber WHERE ContactId = @id";

                return await connection.QueryFirstOrDefaultAsync<ContactEntity>(query, new { id ,firstName, lastName, email, phoneNumber });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update contact object");

                throw;
            }
        }
        public async Task<ContactEntity?> DELETEContactAsync(int id)
        {
            try
            {
                await using var connection = new MySqlConnection(_awsMySqlConnectionString);

                var query = "DELETE from sys.Contact WHERE ContactId = @id";

                return await connection.QueryFirstOrDefaultAsync<ContactEntity>(query, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update contact object");

                throw;
            }
        }
    }
}