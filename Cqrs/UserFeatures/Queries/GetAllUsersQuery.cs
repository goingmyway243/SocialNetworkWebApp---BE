using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserEntity>>
    {
    }
}
