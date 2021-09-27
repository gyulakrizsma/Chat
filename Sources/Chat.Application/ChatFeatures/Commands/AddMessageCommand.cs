using Chat.Domain.Models;
using MediatR;

namespace Chat.Application.ChatFeatures.Commands
{
    public record AddMessageCommand(string User, string Message) : IRequest<MessageItem>;
}
