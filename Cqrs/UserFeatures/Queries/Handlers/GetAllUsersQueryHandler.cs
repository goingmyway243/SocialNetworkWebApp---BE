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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
    {
        private readonly SocialNetworkContext _dbContext;

        public GetAllUsersQueryHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
