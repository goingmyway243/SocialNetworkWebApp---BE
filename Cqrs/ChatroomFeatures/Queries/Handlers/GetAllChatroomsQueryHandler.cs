using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Queries.Handlers
{
    public class GetAllChatroomsQueryHandler : IRequestHandler<GetAllChatroomsQuery, IEnumerable<ChatroomEntity>>
    {
        private readonly ChatroomRepository _repository;

        public GetAllChatroomsQueryHandler(ChatroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ChatroomEntity>> Handle(GetAllChatroomsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
