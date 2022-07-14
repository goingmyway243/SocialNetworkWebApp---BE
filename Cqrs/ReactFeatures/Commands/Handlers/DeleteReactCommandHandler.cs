using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ReactFeatures.Commands.Handlers
{
    public class DeleteReactCommandHandler : IRequestHandler<DeleteReactCommand, Guid>
    {
        private readonly ReactRepository _repository;

        public DeleteReactCommandHandler(ReactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteReactCommand request, CancellationToken cancellationToken)
        {
            var reactToDelete = await _repository.GetById(request.Id);

            if(reactToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(reactToDelete);
        }
    }
}
