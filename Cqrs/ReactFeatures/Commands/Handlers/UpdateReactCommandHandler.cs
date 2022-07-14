using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ReactFeatures.Commands.Handlers
{
    public class UpdateReactCommandHandler : IRequestHandler<UpdateReactCommand, Guid>
    {
        private readonly ReactRepository _repository;

        public UpdateReactCommandHandler(ReactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateReactCommand request, CancellationToken cancellationToken)
        {
            var reactToUpdate = await _repository.GetById(request.Id);

            if (reactToUpdate == null)
            {
                return default;
            }

            reactToUpdate.Type = request.Type;
            reactToUpdate.UpdatedTime = DateTime.Now;

            return await _repository.Update(reactToUpdate);
        }
    }
}
