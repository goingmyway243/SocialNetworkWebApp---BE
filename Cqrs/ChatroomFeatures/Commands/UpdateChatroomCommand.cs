using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands
{
    public class UpdateChatroomCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string ChatroomName { get; set; }
    }
}
