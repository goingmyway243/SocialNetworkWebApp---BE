using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Commands.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Guid>
    {
        private readonly CommentRepository _repository;

        public UpdateCommentCommandHandler(CommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToUpdate = await _repository.GetById(request.Id);

            if (commentToUpdate == null)
            {
                return default;
            }

            commentToUpdate.Comment = request.Comment;
            commentToUpdate.UpdatedTime = DateTime.Now;

            return await _repository.Update(commentToUpdate);
        }
    }
}
