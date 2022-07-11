using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands
{
    public class CreateMessageCommand : IRequest<Guid>
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatroomId { get; set; }
    }
}
