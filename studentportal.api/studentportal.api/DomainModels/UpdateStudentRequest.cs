using System;

namespace studentportal.api.DomainModels
{
    public class UpdateStudentRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public Guid GenderId { get; set; }

        public string PhysicalAddress { get; set; }

        //Navigational
        public string PostalAddress { get; set; }

    }
}
