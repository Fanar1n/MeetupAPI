using AutoMapper;
using Meetup.API.ViewModels.Event;
using Meetup.BLL.Models;

namespace Meetup.API.Mappers
{
    public class MappingProfileAPI : Profile
    {
        public MappingProfileAPI()
        {
            CreateMap<EventViewModel, Event>().ReverseMap();
            CreateMap<ShortEventViewModel, Event>().ReverseMap();
        }
    }
}
