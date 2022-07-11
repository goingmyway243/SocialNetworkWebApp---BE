using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Queries
{
    public class GetChatroomByIdQuery : IRequest<ChatroomEntity>
    {
        public Guid Id { get; set; }
    }
}
