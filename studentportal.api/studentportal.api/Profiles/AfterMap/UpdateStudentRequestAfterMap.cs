using AutoMapper;
using studentportal.api.DataModel;
using studentportal.api.DomainModels;

namespace studentportal.api.Profiles.AfterMap
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, DataModel.Student>
    {
        public void Process(UpdateStudentRequest source, Student destination, ResolutionContext context)
        {
            //throw new System.NotImplementedException();

            destination.Address = new DataModel.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress

            };
        }
    }
}
