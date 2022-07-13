using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Queries.Handlers
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostEntity>>
    {
        private readonly PostRepository _repository;

        public GetAllPostsQueryHandler(PostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PostEntity>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
