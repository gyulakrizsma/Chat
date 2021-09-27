using System.Collections.Generic;
using Chat.Domain.Models;
using MediatR;

namespace Chat.Application.ChatFeatures.Queries
{
    public record GetMessageListQuery : IRequest<IReadOnlyList<MessageItem>>;
}
