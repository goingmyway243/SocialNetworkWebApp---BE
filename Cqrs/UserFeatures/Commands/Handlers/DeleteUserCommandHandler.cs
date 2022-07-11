using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public DeleteUserCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _dbContext
                .Users
                .FirstOrDefaultAsync(user => user.Id == request.Id);

            if(userToDelete == null)
            {
                return default;
            }

            _dbContext.Users.Remove(userToDelete);
            
            await _dbContext.SaveChangesAsync();

            return userToDelete.Id;
        }
    }
}
