using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Queries.Handlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostEntity>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetPostByIdQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PostEntity> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == request.Id);
        }
    }
}
