using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Commands.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly CommentRepository _repository;

        public CreateCommentCommandHandler(CommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var newComment = new CommentEntity();
            newComment.Comment = request.Comment;
            newComment.PostId = request.PostId;
            newComment.UserId = request.UserId;

            return await _repository.Create(newComment);
        }
    }
}
