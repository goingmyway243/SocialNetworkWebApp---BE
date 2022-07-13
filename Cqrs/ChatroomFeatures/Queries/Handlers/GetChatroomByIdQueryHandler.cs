﻿using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Queries.Handlers
{
    public class GetChatroomByIdQueryHandler : IRequestHandler<GetChatroomByIdQuery, ChatroomEntity>
    {
        private readonly ChatroomRepository _repository;

        public GetChatroomByIdQueryHandler(ChatroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChatroomEntity> Handle(GetChatroomByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
