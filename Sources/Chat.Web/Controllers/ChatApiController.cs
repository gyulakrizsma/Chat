using System.Threading.Tasks;
using AutoMapper;
using Chat.Web.Application;
using Chat.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Web.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatApiController : Controller
    {
        private readonly IChatRepository _repository;
        
        private readonly IMapper _mapper;

        public ChatApiController(IChatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ChatDto> GetMessagesAsync()
        {
            var messageItems = await _repository.GetMessages();

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

            var messageItem = await _repository.AddMessageItem(dto.User, dto.Message);

            return messageItem;
        }
    }
}
