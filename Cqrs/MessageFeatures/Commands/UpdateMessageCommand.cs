using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands
{
    public class UpdateMessageCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatroomId { get; set; }
    }
}
