using AdvertApi.DbModels;
using AdvertApi.Models;
using AutoMapper;


namespace AdvertApi
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertModel, AdvertDbModel>();
        }
    }
}
