using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands.Handlers
{
    public class DeleteChatroomCommandHandler : IRequestHandler<DeleteChatroomCommand, Guid>
    {
        private readonly ChatroomRepository _repository;

        public DeleteChatroomCommandHandler(ChatroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteChatroomCommand request, CancellationToken cancellationToken)
        {
            var chatroomToDelete = await _repository.GetById(request.Id);

            if (chatroomToDelete == null)
            {
                return default;
            }

            return await _repository.Delete(chatroomToDelete);
        }
    }
}
