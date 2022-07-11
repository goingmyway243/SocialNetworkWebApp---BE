using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands
{
    public class UpdatePostCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public Guid UserId { get; set; }
        public Guid? SharePostId { get; set; }
    }
}
