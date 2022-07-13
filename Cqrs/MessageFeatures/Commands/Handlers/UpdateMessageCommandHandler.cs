using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands.Handlers
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, Guid>
    {
        private readonly MessageRepository _repository;

        public UpdateMessageCommandHandler(MessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToUpdate = await _repository.GetById(request.Id);

            if (messageToUpdate == null)
            {
                return default;
            }

            messageToUpdate.Message = request.Message;
            messageToUpdate.UpdatedTime = DateTime.Now;

            return await _repository.Update(messageToUpdate);
        }
    }
}
