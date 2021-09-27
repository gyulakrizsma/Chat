using System;
using System.Threading;
using System.Threading.Tasks;
using Chat.Application;
using Chat.Application.ChatFeatures.Commands;
using Chat.Application.ChatFeatures.Commands.Handlers;
using Chat.Domain.Models;
using Moq;
using Xunit;

namespace Chat.Tests
{
    public class AddMessageHandlerTest
    {
        [Fact]
        public async Task Get_Message_List_Handler_Handle_Method_Returns_Values_Correctly()
        {
            // Arrange
            const string user = "User 1";
            const string message = "Message 1";
            var createdAt = DateTime.UtcNow - TimeSpan.FromDays(1);

            var request = new AddMessageCommand(user, message);
            var repositoryMock = SetupChatRepositoryMock(user, message, createdAt);
            var handler = new AddMessageHandler(repositoryMock);

            // Act
            var messageItem = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(user, messageItem.User);
            Assert.Equal(message, messageItem.Message);
            Assert.Equal(createdAt, messageItem.CreatedAt);
        }

        private IChatRepository SetupChatRepositoryMock(string user, string message, DateTime createdDate)
        {
            var mock = new Mock<IChatRepository>();

            mock.Setup(m => m.AddMessageItemAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new MessageItem(user, message, createdDate));

            return mock.Object;
        }
    }
}
