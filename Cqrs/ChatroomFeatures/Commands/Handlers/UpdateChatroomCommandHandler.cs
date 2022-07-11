using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands.Handlers
{
    public class UpdateChatroomCommandHandler : IRequestHandler<UpdateChatroomCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public UpdateChatroomCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateChatroomCommand request, CancellationToken cancellationToken)
        {
            var chatroomToUpdate = await _dbContext
                .Chatrooms
                .FirstOrDefaultAsync(chatroom => chatroom.Id == request.Id);

            if (chatroomToUpdate == null)
            {
                return default;
            }

            chatroomToUpdate.ChatroomName = request.ChatroomName;

            await _dbContext.SaveChangesAsync();

            return chatroomToUpdate.Id;
        }
    }
}
