using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands.Handlers
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, Guid>
    {
        private readonly MessageRepository _repository;

        public DeleteMessageCommandHandler(MessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToDelete = await _repository.GetById(request.Id);

            if (messageToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(messageToDelete);
        }
    }
}
