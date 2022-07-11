using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Queries.Handlers
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageEntity>>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetAllMessagesQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MessageEntity>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Messages.ToListAsync();
        }
    }
}
