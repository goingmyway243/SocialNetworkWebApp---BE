using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Queries
{
    public class GetCommentByIdQuery : IRequest<CommentEntity>
    {
        public Guid Id { get; set; }
    }
}
