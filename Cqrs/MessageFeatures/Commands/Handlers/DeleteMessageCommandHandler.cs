using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands.Handlers
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public DeleteMessageCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToDelete = await _dbContext
                .Messages
                .FirstOrDefaultAsync(message => message.Id == request.Id);

            if (messageToDelete == null)
            {
                return default;
            }

            _dbContext.Messages.Remove(messageToDelete);

            await _dbContext.SaveChangesAsync();

            return messageToDelete.Id;
        }
    }
}
