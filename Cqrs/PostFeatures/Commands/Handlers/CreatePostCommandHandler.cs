using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly PostRepository _repository;

        public CreatePostCommandHandler(PostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new PostEntity();

            newPost.Caption = request.Caption;
            newPost.UserId = request.UserId;
            newPost.SharePostId = request.SharePostId;

            return await _repository.Create(newPost);
        }
    }
}
