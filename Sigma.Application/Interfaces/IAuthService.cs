﻿using Sigma.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponseDTo> Authenticate(AuthenticateRequestDTo request);
    }
}
