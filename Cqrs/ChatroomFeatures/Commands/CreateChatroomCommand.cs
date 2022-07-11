using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands
{
    public class CreateChatroomCommand : IRequest<Guid>
    {
        public string ChatroomName { get; set; }
    }
}
