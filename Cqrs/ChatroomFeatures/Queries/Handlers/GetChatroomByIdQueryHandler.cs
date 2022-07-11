using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Queries.Handlers
{
    public class GetChatroomByIdQueryHandler : IRequestHandler<GetChatroomByIdQuery, ChatroomEntity>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetChatroomByIdQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ChatroomEntity> Handle(GetChatroomByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext
                .Chatrooms
                .FirstOrDefaultAsync(chatroom => chatroom.Id == request.Id);
        }
    }
}
