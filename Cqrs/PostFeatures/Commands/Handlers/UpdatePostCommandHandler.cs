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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public UpdatePostCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postToUpdate = await _dbContext
                .Posts
                .FirstOrDefaultAsync(post => post.Id == request.Id); 

            if(postToUpdate == null)
            {
                return default;
            }

            postToUpdate.Caption = request.Caption;

            await _dbContext.SaveChangesAsync();

            return postToUpdate.Id;
        }
    }
}
