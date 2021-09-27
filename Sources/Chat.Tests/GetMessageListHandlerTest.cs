using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Application;
using Chat.Application.ChatFeatures.Queries;
using Chat.Application.ChatFeatures.Queries.Handlers;
using Chat.Domain.Models;
using Moq;
using Xunit;

namespace Chat.Tests
{
    public class GetMessageListHandlerTest
    {
        [Fact]
        public async Task Get_Message_List_Handler_Handle_Method_Returns_Values_Correctly()
        {
            // Arrange
            var repositoryMock = SetupChatRepositoryMock();
            var request = new GetMessageListQuery();

            var handler = new GetMessageListHandler(repositoryMock);

            // Act
            var messageItems = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotEmpty(messageItems);
            Assert.Equal(3, messageItems.Count);
        }

        private IChatRepository SetupChatRepositoryMock()
        {
            var mock = new Mock<IChatRepository>();

            mock.Setup(m => m.GetMessagesAsync())
                .ReturnsAsync(new[]
                {
                    new MessageItem("Test User 1", "Test message", DateTime.UtcNow),
                    new MessageItem("Test User 2", "Test message 2", DateTime.UtcNow - TimeSpan.FromHours(1)),
                    new MessageItem("Test User 3", "Test message 3", DateTime.UtcNow- TimeSpan.FromHours(2))
                }.ToList());

            return mock.Object;
        }
    }
}
