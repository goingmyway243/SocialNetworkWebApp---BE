using MediatR;
using SocialNetworkWebApp.Models;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ContentFeatures.Commands.Handlers
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, Guid>
    {
        private readonly ContentRepository _repository;

        public CreateContentCommandHandler(ContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var newContent = new ContentEntity();
            newContent.TextContent = request.TextContent;
            newContent.LinkContent = request.LinkContent;
            newContent.Type = request.Type;
            newContent.PostId = request.PostId;

            return await _repository.Create(newContent);
        }
    }
}
