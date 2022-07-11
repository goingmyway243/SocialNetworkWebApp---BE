using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Commands
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
