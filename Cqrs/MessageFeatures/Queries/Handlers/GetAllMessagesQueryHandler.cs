using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Queries.Handlers
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageEntity>>
    {
        private readonly MessageRepository _repository;

        public GetAllMessagesQueryHandler(MessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MessageEntity>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
