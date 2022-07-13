using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ContentFeatures.Commands.Handlers
{
    public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand, Guid>
    {
        private readonly ContentRepository _repository;

        public DeleteContentCommandHandler(ContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var contentToDelete = await _repository.GetById(request.Id);

            if (contentToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(contentToDelete);
        }
    }
}
