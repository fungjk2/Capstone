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
        public async Task<int> postContactAsyncm(string FirstNamex, string LastNamex, string PhoneNumberx, string Emailx)
        {
           return await _contactRepository.postContactAsync(FirstNamex, LastNamex, PhoneNumberx, Emailx);

        }




    }
}