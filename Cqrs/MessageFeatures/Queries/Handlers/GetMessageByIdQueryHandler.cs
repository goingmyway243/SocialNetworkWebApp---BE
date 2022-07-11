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
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageEntity>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetMessageByIdQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageEntity> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext
                .Messages
                .FirstOrDefaultAsync(message => message.Id == request.Id);
        }
    }
}
