using CustomerDataService.Dtos;
using CustomerDataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerDataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;
        public ContactController(IContactRepository contactRepository) => this.contactRepository = contactRepository;

        [HttpGet]
        public async Task<ActionResult<Contact>> GetContactAsync()
        {
            return new Contact
            {
                Email = "mvandenese@costar.com",
                FirstName = "Max",
                LastName = "Vandenesse",
                Id = 1,
                PhoneNumber = "8041234567"
            };
        }
    }
}
