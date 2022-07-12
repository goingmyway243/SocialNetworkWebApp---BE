using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Commands
{
    public class DeleteCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
