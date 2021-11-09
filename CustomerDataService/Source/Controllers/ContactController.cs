using System;
using System.Threading.Tasks;
using CustomerDataService.Dtos;
using CustomerDataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerDataService.Controllers
{

    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactRepository repo, ILogger<ContactController> logger)
        {
            _contactRepository = repo;
            _logger = logger;
        }

        /// <summary>
        /// Get A Contact Given A Phone Number.
        /// </summary>
        /// <returns>Contact data contract</returns>
        [HttpGet]
        public async Task<ActionResult<Contact>> GetContactAsync(string phoneNumber)
        {
            try
            {
                var contact = await _contactRepository.GetContactAsync(phoneNumber);

                if (contact == null)
                    return NotFound($"No contact found by phone number {phoneNumber}.");

                return Ok(new Contact
                {
                    Id = contact.ContactId,
                    Email = contact.Email,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting contact by phone number.");

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContactAsync(CreateContactRequest request)
        {
            try
            {
                var contact = await _contactRepository.CreateContactAsync(request);

            return Ok(new Contact
            {
                Id = contact?.ContactId ?? default,
                Email = contact?.Email,
                FirstName = contact?.FirstName,
                LastName = contact?.LastName,
                PhoneNumber = contact?.PhoneNumber
            });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting contact by phone number.");

                return BadRequest(ex);
            }
        }


        [HttpPut("/{id}")]
        public async Task<ActionResult<Contact>> PutContactAsync(int id, string Email, string FirstName, string LastName, string PhoneNumber)
        {

            var contact = await _contactRepository.UpdateContactAsync(id, Email, FirstName, LastName, PhoneNumber);

            if (id == null)
            {
                return NotFound($"ID is required.");
            }


            return Ok(new Contact
            {

                Email = contact?.Email,
                FirstName = contact?.FirstName,
                LastName = contact?.LastName,
                PhoneNumber = contact?.PhoneNumber
            });


        }
        [HttpDelete("/{id}")]
        public async Task<ActionResult<Contact>> DELETEContactAsync(int id)
        {

            var contact = await _contactRepository.DELETEContactAsync(id);


            return Ok(new Contact
            {

                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber
            });

        }
    }
}