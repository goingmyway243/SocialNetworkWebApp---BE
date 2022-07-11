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
    public class GetAllChatroomsQueryHandler : IRequestHandler<GetAllChatroomsQuery, IEnumerable<ChatroomEntity>>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetAllChatroomsQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ChatroomEntity>> Handle(GetAllChatroomsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Chatrooms.ToListAsync();
        }
    }
}
