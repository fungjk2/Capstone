using System.Runtime.Serialization;

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
    }
}
