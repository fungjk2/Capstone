using System.Runtime.Serialization;

namespace CustomerDataService.Dtos
{
    [DataContract]
    public class CreateContactRequest
    {
        public CreateContactRequest() { }
        public CreateContactRequest(string firstName, string lastName, string email, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        [DataMember(IsRequired = false)]
        public string FirstName { get; set; }

        [DataMember(IsRequired = false)]
        public string LastName { get; set; }

        [DataMember(IsRequired = false)]
        public string PhoneNumber { get; set; }

        [DataMember(IsRequired = false)]
        public string Email { get; set; }
    }
}
