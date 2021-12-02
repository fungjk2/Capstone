using System.Runtime.Serialization;
using CustomerDataService.Entities;

namespace CustomerDataService.Dtos
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string? FirstName { get; set; }

        [DataMember]
        public string? LastName { get; set; }

        [DataMember]
        public string? PhoneNumber { get; set; }

        [DataMember]
        public string? Email { get; set; }

        public Contact(ContactEntity contact)
        {
            Id = contact.ContactId;
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = contact.Email;
            PhoneNumber = contact.PhoneNumber;
        }
       
    }
}
