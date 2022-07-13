using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ContentFeatures.Queries.Handlers
{
    public class GetAllContentsQueryHandler : IRequestHandler<GetAllContentsQuery, IEnumerable<ContentEntity>>
    {
        private readonly ContentRepository _repository;

        public GetAllContentsQueryHandler(ContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContentEntity>> Handle(GetAllContentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
