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
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostEntity>>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetAllPostsQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PostEntity>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Posts.ToListAsync();
        }
    }
}
