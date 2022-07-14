using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ReactFeatures.Commands.Handlers
{
    public class CreateReactCommandHandler : IRequestHandler<CreateReactCommand, Guid>
    {
        private readonly ReactRepository _repository;

        public CreateReactCommandHandler(ReactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateReactCommand request, CancellationToken cancellationToken)
        {
            var newReact = new ReactEntity();
            newReact.Type = request.Type;
            newReact.PostId = request.PostId;
            newReact.UserId = request.UserId;

            return await _repository.Create(newReact);
        }
    }
}
