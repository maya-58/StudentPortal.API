using System;
namespace studentportal.api.DataModel
{
    public class Student
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
        public Gender Gender { get; set; }

        public Address Address { get; set; }

    }
}
