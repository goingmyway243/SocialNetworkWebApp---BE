using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands
{
    public class DeleteMessageCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
