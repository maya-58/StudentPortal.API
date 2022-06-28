using System;

namespace studentportal.api.DomainModels
{
    public class StudentDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public string ProfileImageURl { get; set; }

        public Guid GenderId { get; set; }

        //Navigational
        public GenderDTO Gender { get; set; }

        public AddressDTO Address { get; set; }
    }
}
