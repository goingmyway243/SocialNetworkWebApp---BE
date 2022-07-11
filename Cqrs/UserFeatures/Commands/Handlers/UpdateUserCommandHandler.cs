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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public UpdateUserCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _dbContext
                .Users
                .FirstOrDefaultAsync(user => user.Id == request.Id);

            if (userToUpdate == null)
            {
                return default;
            }

            userToUpdate.Email = request.Email;
            userToUpdate.Password = request.Password;
            userToUpdate.FirstName = request.FirstName;
            userToUpdate.LastName = request.LastName;
            userToUpdate.Phone = request.Phone;
            userToUpdate.DateOfBirth = request.DateOfBirth;

            await _dbContext.SaveChangesAsync();

            return userToUpdate.Id;
        }
    }
}
