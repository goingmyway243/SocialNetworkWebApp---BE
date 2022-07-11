using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands
{
    public class DeletePostCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
