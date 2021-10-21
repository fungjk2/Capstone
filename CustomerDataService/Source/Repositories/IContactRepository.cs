using System.Threading.Tasks;
using CustomerDataService.Entities;

namespace CustomerDataService.Repositories
{

    public interface IContactRepository
    {
        public Task<ContactEntity> GetContactAsync(string phoneNumber);
        public Task<int> postContactAsync(string FirstNamex, string LastNamex, string PhoneNumberx, string Emailx);
    }
    
}