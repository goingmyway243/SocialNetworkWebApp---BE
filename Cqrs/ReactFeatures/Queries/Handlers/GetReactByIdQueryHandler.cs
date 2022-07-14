using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ReactFeatures.Queries.Handlers
{
    public class GetReactByIdQueryHandler : IRequestHandler<GetReactByIdQuery, ReactEntity>
    {
        private readonly ReactRepository _repository;

        public GetReactByIdQueryHandler(ReactRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReactEntity> Handle(GetReactByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
