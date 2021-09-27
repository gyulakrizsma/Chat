using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Application.ChatFeatures.Commands;
using Chat.Application.ChatFeatures.Queries;
using Chat.Domain.Models;
using Chat.Web.Controllers;
using Chat.Web.Dtos;
using Chat.Web.MappingProfiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Chat.Tests
{
    public class ChatApiControllerTest
    {
        private static IMapper _mapper;

        public ChatApiControllerTest()
        {
            if (_mapper != null) return;

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new ChatMappingProfile()));

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task Get_Message_Async_Returns_Valid_Chat_Dto()
        {
            // Arrange
            var mediatorMock = SetupMediatorMock();
            var service = new ChatApiController(mediatorMock, _mapper);

            // Act
            var resultDto = await service.GetMessagesAsync();

            // Assert
            Assert.NotEmpty(resultDto.Messages);
            Assert.Equal(3, resultDto.Messages.Count);
        }
        
        [Fact]
        public async Task Add_Message_Async_Returns_Valid_Message_Item_Dto()
        {
            // Arrange
            const string user = "User 1";
            const string message = "Message 1";
            var createdAt = DateTime.UtcNow - TimeSpan.FromDays(1);
            var dto = new AddMessageDto {User = user, Message = message};

            var mediatorMock = SetupMediatorMock(user, message, createdAt);
            var service = new ChatApiController(mediatorMock, _mapper);

            // Act
            var resultDto = await service.AddMessageAsync(dto);

            // Assert
            var responseDto = resultDto as MessageItemDto;

            Assert.NotNull(responseDto);
            Assert.Equal(user, responseDto.User);
            Assert.Equal(message, responseDto.Message);
        }
        
        [Theory]
        [MemberData(nameof(TestSets))]
        public async Task Add_Message_Async_Returns_Bad_Request_When_Dto_Is_Invalid(AddMessageDto dto, string errorMessage)
        {
            // Arrange
            var createdAt = DateTime.UtcNow - TimeSpan.FromDays(1);

            var mediatorMock = SetupMediatorMock(dto.User, dto.Message, createdAt);
            var service = new ChatApiController(mediatorMock, _mapper);

            // Act
            var resultDto = await service.AddMessageAsync(dto);

            // Assert
            var response = resultDto as BadRequestObjectResult;

            Assert.NotNull(response);
            Assert.Equal((int?) HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(errorMessage, response.Value);
        }

        public static IEnumerable<object[]> TestSets => new[]
        {
            new object[] {  new AddMessageDto {User = "", Message = "Message 1"}, "User is empty" }, // User is empty
            new object[] {  new AddMessageDto {User = "User 1", Message = ""}, "Message is empty" }, // Message is empty
            
        };

        private static IMediator SetupMediatorMock()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(m => m.Send(It.IsAny<GetMessageListQuery>(), CancellationToken.None)).ReturnsAsync(new[]
            {
                new MessageItem("Test User 1", "Test message", DateTime.UtcNow),
                new MessageItem("Test User 2", "Test message 2", DateTime.UtcNow - TimeSpan.FromHours(1)),
                new MessageItem("Test User 3", "Test message 3", DateTime.UtcNow - TimeSpan.FromHours(2))
            }.ToList());

            return mock.Object;
        }

        private static IMediator SetupMediatorMock(string user, string message, DateTime createdAt)
        {
            var mock = new Mock<IMediator>();

            mock.Setup(m => m.Send(It.IsAny<AddMessageCommand>(), CancellationToken.None)).ReturnsAsync(new MessageItem(user, message, createdAt));

            return mock.Object;
        }
    }
}
