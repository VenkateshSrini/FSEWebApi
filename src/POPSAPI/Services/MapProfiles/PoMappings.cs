using AutoMapper;
using POPSAPI.Model;
using POPSAPI.ViewModel;

namespace POPSAPI.Services.MapProfiles
{
    public class PoMappings : Profile
    {
        public PoMappings()
        {
            CreateMap<PoDetail, PoDetailVM>()
                .ForMember(dest => dest.ItemNumber, options =>
                   options.MapFrom(src => src.ItemNumber))
                .ForMember(dest => dest.Quantity, options =>
                  options.MapFrom(src => src.Quantity))
                .ReverseMap();
            CreateMap<PoMaster, PoVM>()
                .ForMember(dest => dest.ID, options =>
                  options.MapFrom(src => src.PoNumber))
                .ForMember(dest => dest.Details, options =>
                  options.MapFrom(src => src.Details))
                .ForMember(dest => dest.PurchaseDate, options =>
                  options.MapFrom(src => src.PoDate))
                .ForMember(dest => dest.SupplierNumber, options =>
                  options.MapFrom(src => src.SUPLNO))
                .ReverseMap();

        }
    }
}
