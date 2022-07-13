using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Commands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly UserRepository _repository;

        public DeleteUserCommandHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _repository.GetById(request.Id);

            if (userToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(userToDelete);
        }
    }
}
