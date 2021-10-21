using System.Threading.Tasks;
using CustomerDataService.Dtos;
using CustomerDataService.Entities;

namespace CustomerDataService.Repositories
{

    public interface IContactRepository
    {
        public Task<ContactEntity> GetContactAsync(string phoneNumber);
        public Task<ContactEntity?> CreateContactAsync(CreateContactRequest request);
    }
    
}