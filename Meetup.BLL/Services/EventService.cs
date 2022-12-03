using AutoMapper;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Meetup.DAL.Interfaces;
using MeetupAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        protected readonly IMapper _mapper;

        public EventService(
            IEventRepository eventRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public virtual async Task<IEnumerable<Event>> GetAllAsync(CancellationToken token)
        {
            var result = await _eventRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<Event>>(result);
        }

        public async Task<Event> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _eventRepository.GetByIdAsync(id, token);

            return _mapper.Map<Event>(result);
        }

        public virtual async Task<Event> CreateAsync(Event item, CancellationToken token)
        {
            var eventEntity = _mapper.Map<EventEntity>(item);
            var result = await _eventRepository.CreateAsync(eventEntity, token);

            return _mapper.Map<Event>(result);
        }

        public virtual async Task<Event> UpdateAsync(Event item, CancellationToken token)
        {
            var eventEntity = _mapper.Map<EventEntity>(item);
            var result = await _eventRepository.UpdateAsync(eventEntity, token);

            return _mapper.Map<Event>(result);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var eventModel = await _eventRepository.GetByIdAsync(id, token);

            if (eventModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _eventRepository.DeleteByIdAsync(id, token);
        }
    }
}
