﻿namespace CustomerDataService.Entities
{

    public class ContactEntity
    {
        public int ContactId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}