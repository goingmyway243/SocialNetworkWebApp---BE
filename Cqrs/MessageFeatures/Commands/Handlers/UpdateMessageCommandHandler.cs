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
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public UpdateMessageCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToUpdate = await _dbContext
                .Messages
                .FirstOrDefaultAsync(message => message.Id == request.Id);

            if (messageToUpdate == null)
            {
                return default;
            }

            messageToUpdate.Message = request.Message;

            await _dbContext.SaveChangesAsync();

            return messageToUpdate.Id;
        }
    }
}
