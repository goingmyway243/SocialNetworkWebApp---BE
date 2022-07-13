using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.FriendshipFeatures.Commands.Handlers
{
    public class DeleteFriendshipCommandHandler : IRequestHandler<DeleteFriendshipCommand, Guid>
    {
        private readonly FriendshipRepository _repository;

        public DeleteFriendshipCommandHandler(FriendshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteFriendshipCommand request, CancellationToken cancellationToken)
        {
            var friendshipToDelete = await _repository.GetById(request.Id);

            if (friendshipToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(friendshipToDelete);
        }
    }
}
