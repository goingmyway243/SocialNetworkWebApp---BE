using MediatR;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public CreateUserCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUSer = new UserEntity();

            newUSer.Email = request.Email;
            newUSer.Password = request.Password;
            newUSer.FirstName = request.FirstName;
            newUSer.LastName = request.LastName;
            newUSer.Phone = request.Phone;
            newUSer.DateOfBirth = request.DateOfBirth;

            _dbContext.Users.Add(newUSer);

            await _dbContext.SaveChangesAsync();

            return newUSer.Id;
        }
    }
}
