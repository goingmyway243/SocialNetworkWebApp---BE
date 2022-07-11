using MediatR;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands.Handlers
{
    public class CreateChatroomCommandHandler : IRequestHandler<CreateChatroomCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public CreateChatroomCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateChatroomCommand request, CancellationToken cancellationToken)
        {
            var newChatroom = new ChatroomEntity();

            newChatroom.ChatroomName = request.ChatroomName;

            _dbContext.Chatrooms.Add(newChatroom);

            await _dbContext.SaveChangesAsync();

            return newChatroom.Id;
        }
    }
}
