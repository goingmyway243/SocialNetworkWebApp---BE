using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetUserByIdQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext
                .Users
                .FirstOrDefaultAsync(user => user.Id == request.Id);
        }
    }
}
