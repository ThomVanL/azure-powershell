﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Class implementing a chain of responsibility pattern for authenticators
    /// </summary>
    public abstract class DelegatingAuthenticator : IAuthenticator
    {
        protected Action EmptyAction = () => { };

        public IAuthenticator Next { get; set; }
        public abstract bool CanAuthenticate(AuthenticationParameters parameters);
        public abstract Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken);

        public Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var source = new CancellationTokenSource();
            return Authenticate(parameters, source.Token);
        }

        public bool TryAuthenticate(AuthenticationParameters parameters, out Task<IAccessToken> token)
        {
            var source = new CancellationTokenSource();
            return TryAuthenticate(parameters, source.Token, out token);
        }

        public bool TryAuthenticate(AuthenticationParameters parameters, CancellationToken cancellationToken, out Task<IAccessToken> token)
        {
            token = null;
            if (CanAuthenticate(parameters))
            {
                token = Authenticate(parameters, cancellationToken);
                return true;
            }

            if (Next != null)
            {
                return Next.TryAuthenticate(parameters, cancellationToken, out token);
            }

            return false;
        }
    }
}
