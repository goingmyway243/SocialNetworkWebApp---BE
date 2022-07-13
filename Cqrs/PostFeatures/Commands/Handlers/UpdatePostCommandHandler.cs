using MediatR;
using SocialNetworkWebApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Commands.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Guid>
    {
        private readonly PostRepository _repository;

        public UpdatePostCommandHandler(PostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postToUpdate = await _repository.GetById(request.Id);

            if(postToUpdate == null)
            {
                return default;
            }

            postToUpdate.Caption = request.Caption;
            postToUpdate.UpdatedTime = DateTime.Now;

            return await _repository.Update(postToUpdate);
        }
    }
}
