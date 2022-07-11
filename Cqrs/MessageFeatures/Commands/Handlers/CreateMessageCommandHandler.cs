using MediatR;
using SocialNetworkWebApp.Context;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Commands.Handlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly SocialNetworkContext _dbContext;

        public CreateMessageCommandHandler(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var newMessage = new MessageEntity();

            newMessage.Message = request.Message;
            newMessage.UserId = request.UserId;
            newMessage.ChatroomId = request.ChatroomId;

            _dbContext.Messages.Add(newMessage);

            await _dbContext.SaveChangesAsync();

            return newMessage.Id;
        }
    }
}
