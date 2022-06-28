using AutoMapper;
using DataModels=studentportal.api.DataModel;
using   studentportal.api.DomainModels;

namespace studentportal.api.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, StudentDTO>()
                .ReverseMap();

            CreateMap<DataModels.Gender, GenderDTO>()
           .ReverseMap();

            CreateMap<DataModels.Address, AddressDTO>()
           .ReverseMap();
        }

    }
}
