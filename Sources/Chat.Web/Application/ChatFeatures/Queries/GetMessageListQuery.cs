using System.Collections.Generic;
using Chat.Web.Domain.Models;
using MediatR;

namespace Chat.Web.Application.ChatFeatures.Queries
{
    public record GetMessageListQuery : IRequest<IReadOnlyList<MessageItem>>;
}
