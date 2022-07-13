using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ContentFeatures.Queries.Handlers
{
    public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, ContentEntity>
    {
        private readonly ContentRepository _repository;

        public GetContentByIdQueryHandler(ContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContentEntity> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
