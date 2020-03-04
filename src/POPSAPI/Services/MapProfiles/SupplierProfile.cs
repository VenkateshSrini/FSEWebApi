using AutoMapper;
using POPSAPI.Model;
using POPSAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Services.MapProfiles
{
    public class SupplierProfile:Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierVM>()
                .ForMember(dest => dest.ID, options =>
                  options.MapFrom(src => src.SupplierNumber))
                .ForMember(dest => dest.Name, options =>
                  options.MapFrom(src => src.SupplierName))
                .ForMember(dest => dest.Address, options =>
                  options.MapFrom(src => src.SupplierAddress))
                .ReverseMap();
        }
    }
}
