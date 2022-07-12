using AutoMapper;
using studentportal.api.DataModel;
using studentportal.api.DomainModels;
using System;

namespace studentportal.api.Profiles.AfterMap
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModel.Student>
    {
        public void Process(AddStudentRequest source, Student destination, ResolutionContext context)
        {
            // throw new System.NotImplementedException();
            destination.Id = Guid.NewGuid();
            destination.Address = new DataModel.Address
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress

            };
        }
    }
}
