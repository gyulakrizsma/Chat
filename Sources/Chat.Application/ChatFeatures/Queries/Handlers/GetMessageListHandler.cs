using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chat.Domain.Models;
using MediatR;

namespace Chat.Application.ChatFeatures.Queries.Handlers
{
    public class GetMessageListHandler : IRequestHandler<GetMessageListQuery, IReadOnlyList<MessageItem>>
    {
        private readonly IChatRepository _repository;

        public GetMessageListHandler(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<MessageItem>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMessagesAsync();
        }
    }
}
