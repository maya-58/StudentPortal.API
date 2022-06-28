using System;
namespace studentportal.api.DataModel
{
    public class Address
    {
        public Guid Id { get; set; }

        public string PhysicalAddress { get; set; }

        //Navigational
        public string PostalAddress { get; set; }

        public Guid StudentId { get; set; }

    }
}
