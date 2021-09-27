using System.Threading;
using System.Threading.Tasks;
using Chat.Domain.Models;
using MediatR;

namespace Chat.Application.ChatFeatures.Commands.Handlers
{
    public class AddMessageHandler : IRequestHandler<AddMessageCommand, MessageItem>
    {
        private readonly IChatRepository _repository;

        public AddMessageHandler(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageItem> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddMessageItem(request.User, request.Message);
        }
    }
}
