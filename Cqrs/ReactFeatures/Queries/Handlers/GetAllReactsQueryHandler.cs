using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ReactFeatures.Queries.Handlers
{
    public class GetAllReactsQueryHandler : IRequestHandler<GetAllReactsQuery, IEnumerable<ReactEntity>>
    {
        private readonly ReactRepository _repository;

        public GetAllReactsQueryHandler(ReactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReactEntity>> Handle(GetAllReactsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
