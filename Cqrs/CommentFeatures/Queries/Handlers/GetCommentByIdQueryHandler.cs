using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Queries.Handlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentEntity>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetCommentByIdQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommentEntity> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext
                .Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.Id);
        }
    }
}
