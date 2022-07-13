using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.FriendshipFeatures.Queries.Handlers
{
    public class GetAllFriendshipsQueryHandler : IRequestHandler<GetAllFriendshipsQuery, IEnumerable<FriendshipEntity>>
    {
        private readonly FriendshipRepository _repository;

        public GetAllFriendshipsQueryHandler(FriendshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FriendshipEntity>> Handle(GetAllFriendshipsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
