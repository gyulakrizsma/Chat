using System.Threading.Tasks;
using AutoMapper;
using Chat.Application.ChatFeatures.Commands;
using Chat.Application.ChatFeatures.Queries;
using Chat.Web.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatApiController : Controller
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public ChatApiController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ChatDto> GetMessagesAsync()
        {
            var messageItems = await _mediator.Send(new GetMessageListQuery());

            return _mapper.Map<ChatDto>(messageItems);
        }

        [HttpPost]
        public async Task<dynamic> AddMessageAsync(AddMessageDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Message))
            {
                return BadRequest("Message is empty");
            }

            if (string.IsNullOrWhiteSpace(dto.User))
            {
                return BadRequest("User is empty");
            }

            var messageItem = await _mediator.Send(new AddMessageCommand(dto.User, dto.Message));

            return _mapper.Map<MessageItemDto>(messageItem);
        }
    }
}
