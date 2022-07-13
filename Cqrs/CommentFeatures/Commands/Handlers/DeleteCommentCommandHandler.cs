using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.CommentFeatures.Commands.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Guid>
    {
        private readonly CommentRepository _repository;

        public DeleteCommentCommandHandler(CommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToDelete = await _repository.GetById(request.Id);

            if(commentToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(commentToDelete);
        }
    }
}
