using System.Threading.Tasks;
using CustomerDataService.Dtos;
using CustomerDataService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository repo)
    {
        _contactRepository = repo;
    }

    /// <summary>
    ///     Get A Contact Given A Phone Number.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Contact>> GetContactAsync()
    {
        await _contactRepository.GetContactAsync("123432");

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