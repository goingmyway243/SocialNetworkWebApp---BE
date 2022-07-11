using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.MessageFeatures.Queries
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<MessageEntity>>
    {
    }
}
