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

                return Ok(new Contact(await _contactRepository.GetContactAsync(phoneNumber)));
                
                    
                
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

                return Ok(new Contact(await _contactRepository.CreateContactAsync(request)));
           
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting contact by phone number.");

                return BadRequest(ex);
            }
        }


        [HttpPut("/{id}")]
        public async Task<ActionResult<Contact>> PutContactAsync(int id, UpdateContactRequest request)
        {
            try
            {

                if (id == 0)
                {
                    return NotFound($"ID is required.");
                }

                var rcontact = await _contactRepository.UpdateContactAsync(id, request.FirstName, request.LastName, request.Email, request.PhoneNumber);


                return Ok(rcontact);
            }
                catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating contact.");

                return BadRequest(ex);
            }

              

            
            }
        [HttpDelete("/{id}")]
        public async Task<ActionResult<Contact>> DELETEContactAsync(int id)
        {
            try { 
                var contact = await _contactRepository.DELETEContactAsync(id);


                return Ok(new Contact(await _contactRepository.DELETEContactAsync(id))
                {
                    
                });
            }
                catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating contact.");

            return BadRequest(ex);
    }
}
    }
}