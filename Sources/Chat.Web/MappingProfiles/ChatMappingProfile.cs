using System.Collections.Generic;
using AutoMapper;
using Chat.Web.Domain.Models;
using Chat.Web.Dtos;

namespace Chat.Web.MappingProfiles
{
    public class ChatMappingProfile : Profile
    {
        public ChatMappingProfile()
        {
            CreateMap<IReadOnlyCollection<MessageItem>, ChatDto>()
                .ForMember(d => d.Messages, o => o.MapFrom(s => s));

            CreateMap<MessageItem, MessageItemDto>();
        }
    }
}
