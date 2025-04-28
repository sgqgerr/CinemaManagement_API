using AutoMapper;
using CinemaManagement_API.Models;
using DataAccess.Entities;

namespace CinemaManagement_API
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {

            CreateMap<AddFilmModel, Film>();

            CreateMap<AddHallModel, Hall>();

            CreateMap<AddSessionModel, Session>();

            CreateMap<AddSalesModel, Sales>();

            CreateMap<AddTicketModel, Ticket>();

            CreateMap<AddUserModel, User>();

            CreateMap<AddDiscountModel, Discount>();

        }

    }
}
