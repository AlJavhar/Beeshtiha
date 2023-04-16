using AutoMapper;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using Beeshtiha.Service.DTOs.Dish;
using Beeshtiha.Service.DTOs.User;

namespace Beeshtiha.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();

        //Card
        CreateMap<Card, CardForCreationDto>().ReverseMap();
        CreateMap<Card, CardForResultDto>().ReverseMap();

        //Dish
        CreateMap<Dish, DishForCreationDto>().ReverseMap();
        CreateMap<Dish, DishForResultDto>().ReverseMap();
    }
}
