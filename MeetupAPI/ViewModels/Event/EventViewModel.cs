using System;

namespace Meetup.API.ViewModels.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public DateTime DateTimeOfThe { get; set; }

        public string Place { get; set; }

        public string Organizer { get; set; }

        public string Speaker { get; set; }
    }
}
