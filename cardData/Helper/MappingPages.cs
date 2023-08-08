using cardData.Dto;
using cardData.Models;
using AutoMapper;

namespace cardData.Helper
{
    public class MappingPages:Profile
    {
        public MappingPages()
        {
            CreateMap<Card, CardDto>();
            CreateMap<CardDto,Card>();
        }
        }
}
