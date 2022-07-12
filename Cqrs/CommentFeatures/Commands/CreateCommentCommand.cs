using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Commands
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
