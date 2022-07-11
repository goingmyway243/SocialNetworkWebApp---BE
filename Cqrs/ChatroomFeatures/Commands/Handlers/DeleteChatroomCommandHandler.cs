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
    public class DeleteChatroomCommandHandler : IRequestHandler<DeleteChatroomCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public DeleteChatroomCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteChatroomCommand request, CancellationToken cancellationToken)
        {
            var chatroomToDelete = await _dbContext
                .Chatrooms
                .FirstOrDefaultAsync(chatroom => chatroom.Id == request.Id);

            if (chatroomToDelete == null)
            {
                return default;
            }

            _dbContext.Chatrooms.Remove(chatroomToDelete);

            await _dbContext.SaveChangesAsync();

            return chatroomToDelete.Id;
        }
    }
}
