using AutoMapper;
using POPSAPI.Model;
using POPSAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Services.MapProfiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemVM>()
                .ForMember(dest => dest.ID, options =>
                options.MapFrom(src => src.ItemCode))
                .ForMember(dest => dest.Description, options =>
                  options.MapFrom(src => src.ItemDescription))
                .ForMember(dest => dest.Rate, options =>
                  options.MapFrom(src => src.ItemRate))
                .ReverseMap();
        }
    }
}
