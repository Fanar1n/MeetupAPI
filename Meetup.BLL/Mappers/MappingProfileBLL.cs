using AutoMapper;
using Meetup.BLL.Models;
using MeetupAPI.DAL.Entities;

namespace Meetup.BLL.Mappers
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<Event, EventEntity>().ReverseMap();
        }
    }
}
