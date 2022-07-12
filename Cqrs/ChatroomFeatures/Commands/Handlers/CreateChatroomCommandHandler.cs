using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Commands.Handlers
{
    public class CreateChatroomCommandHandler : IRequestHandler<CreateChatroomCommand, Guid>
    {
        private readonly ChatroomRepository _repository;

        public CreateChatroomCommandHandler(ChatroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateChatroomCommand request, CancellationToken cancellationToken)
        {
            var newChatroom = new ChatroomEntity();
            newChatroom.ChatroomName = request.ChatroomName;

            return await _repository.Create(newChatroom);
        }
    }
}
