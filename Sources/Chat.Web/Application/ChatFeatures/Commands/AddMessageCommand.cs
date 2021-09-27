using Chat.Web.Domain.Models;
using MediatR;

namespace Chat.Web.Application.ChatFeatures.Commands
{
    public record AddMessageCommand(string User, string Message) : IRequest<MessageItem>;
}
