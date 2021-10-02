using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerDataService.Dtos;

namespace CustomerDataService.Repositories
{

    public interface IContactRepository
    {
        public Task<ContactEntity> GetContactAsync(string phoneNumber);
    }
}