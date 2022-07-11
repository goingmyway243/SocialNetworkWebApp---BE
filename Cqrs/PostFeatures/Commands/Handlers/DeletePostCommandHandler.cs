using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands.Handlers
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public DeletePostCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = await _dbContext
                .Posts
                .FirstOrDefaultAsync(post => post.Id == request.Id);

            if(postToDelete == null)
            {
                return default;
            }

            _dbContext.Posts.Remove(postToDelete);

            await _dbContext.SaveChangesAsync();

            return postToDelete.Id;
        }
    }
}
