using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands.Handlers
{
    public class UpdateChatroomCommandHandler : IRequestHandler<UpdateChatroomCommand, Guid>
    {
        private readonly ChatroomRepository _repository;

        public UpdateChatroomCommandHandler(ChatroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateChatroomCommand request, CancellationToken cancellationToken)
        {
            var chatroomToUpdate = await _repository.GetById(request.Id);

            if (chatroomToUpdate == null)
            {
                return default;
            }

            chatroomToUpdate.ChatroomName = request.ChatroomName;

            return await _repository.Update(chatroomToUpdate);
        }
    }
}
