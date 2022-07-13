using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.FriendshipFeatures.Queries.Handlers
{
    public class GetFriendshipByIdQueryHandler : IRequestHandler<GetFriendshipByIdQuery, FriendshipEntity>
    {
        private readonly FriendshipRepository _repository;

        public GetFriendshipByIdQueryHandler(FriendshipRepository repository)
        {
            _repository = repository;
        }

        public async Task<FriendshipEntity> Handle(GetFriendshipByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
