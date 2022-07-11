using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.ChatroomFeatures.Queries
{
    public class GetAllChatroomsQuery : IRequest<IEnumerable<ChatroomEntity>>
    {
    }
}
