﻿using MediatR;
using SocialNetworkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Cqrs.PostFeatures.Queries
{
    public class GetPostByIdQuery : IRequest<PostEntity>
    {
        public Guid Id { get; set; }
    }
}
