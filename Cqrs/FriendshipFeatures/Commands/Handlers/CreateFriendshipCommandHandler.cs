using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.FriendshipFeatures.Commands.Handlers
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFriendshipCommand, Guid>
    {
        private readonly FriendshipRepository _repository;

        public CreateFriendshipCommandHandler(FriendshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateFriendshipCommand request, CancellationToken cancellationToken)
        {
            var newFriendship = new FriendshipEntity();
            newFriendship.UserId = request.UserId;
            newFriendship.FriendId = request.FriendId;
            newFriendship.Status = request.Status;

            return await _repository.Create(newFriendship);
        }
    }
}
