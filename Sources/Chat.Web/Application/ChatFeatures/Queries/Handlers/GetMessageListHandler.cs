using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Web.Domain.Models;
using MediatR;

namespace Chat.Web.Application.ChatFeatures.Queries.Handlers
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
            return (await _repository.GetMessages()).OrderBy(mi => mi.CreatedAt).ToList();
        }
    }
}
