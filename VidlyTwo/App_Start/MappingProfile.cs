using AutoMapper;
using VidlyTwo.Dto;
using VidlyTwo.Models;

namespace VidlyTwo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}