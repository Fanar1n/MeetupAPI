using AutoMapper;
using Meetup.API.ViewModels.Event;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(
            IEventService eventService,
            IMapper mapper)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShortEventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _eventService.GetByIdAsync(id, token);

            return Ok(_mapper.Map<ShortEventViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken token)
        {
            var result = await _eventService.GetAllAsync(token);

            return Ok(_mapper.Map<IEnumerable<EventViewModel>>(result));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken token)
        {
            await _eventService.DeleteByIdAsync(id, token);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(EventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(EventViewModel clientViewModel, CancellationToken token)
        {
            var eventModel = _mapper.Map<Event>(clientViewModel);
            var result = await _eventService.UpdateAsync(eventModel, token);

            return Ok(_mapper.Map<EventViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShortEventViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(ShortEventViewModel addClientViewModel, CancellationToken token)
        {
            var eventModel = _mapper.Map<Event>(addClientViewModel);
            var result = await _eventService.CreateAsync(eventModel, token);

            return Ok(_mapper.Map<ShortEventViewModel>(result));
        }
    }
}
