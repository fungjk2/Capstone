using System;
using System.Threading.Tasks;
using CustomerDataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerDataService.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        ///     Get A Contact Given A Phone Number.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetContact")]
        public async Task<ActionResult> GetContactAsync(string phoneNumber)
        {
            try
            {
                var contact = await _contactRepository.GetContactAsync(phoneNumber);
                if (contact == null)
                    return NotFound($"No contact found by phone number {phoneNumber}.");
                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting contact by phone number.");
                return BadRequest(ex);
            }
        }
    }
}