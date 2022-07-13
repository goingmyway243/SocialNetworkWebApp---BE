using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Queries.Handlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentEntity>>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetAllCommentsQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CommentEntity>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Comments.ToListAsync();
        }
    }
}
