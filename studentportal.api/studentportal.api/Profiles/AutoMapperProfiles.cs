using AutoMapper;
using DataModels=studentportal.api.DataModel;
using   studentportal.api.DomainModels;
using studentportal.api.Profiles.AfterMap;

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

            CreateMap<UpdateStudentRequest, DataModel.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
              //  .ForMember(dest => dest.Address.PhysicalAddress, opt => opt.MapFrom(src => src.PhysicalAddress))
              //  .ForMember(dest => dest.Address.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress));
          //.ReverseMap();

            
        }

    }
}
