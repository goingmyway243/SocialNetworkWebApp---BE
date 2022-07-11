using MediatR;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public CreatePostCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new PostEntity();
            
            newPost.Caption = request.Caption;
            newPost.UserId = request.UserId;
            newPost.SharePostId = request.SharePostId;

            _dbContext.Posts.Add(newPost);
            
            await _dbContext.SaveChangesAsync();

            return newPost.Id;
        }
    }
}
