﻿using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.FriendshipFeatures.Commands.Handlers
{
    public class UpdateFriendshipCommandHandler : IRequestHandler<UpdateFriendshipCommand, Guid>
    {
        private readonly FriendshipRepository _repository;

        public UpdateFriendshipCommandHandler(FriendshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateFriendshipCommand request, CancellationToken cancellationToken)
        {
            var friendshipToUpdate = await _repository.GetById(request.Id);

            if (friendshipToUpdate == null)
            {
                return default;
            }

            friendshipToUpdate.Status = request.Status;
            friendshipToUpdate.UpdatedTime = DateTime.Now;

            return await _repository.Update(friendshipToUpdate);
        }
    }
}
