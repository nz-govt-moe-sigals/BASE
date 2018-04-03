﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISessionService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISessionService" />
    public class SessionService : AppCoreServiceBase, ISessionService
    {
        private readonly IRepositoryService _repositoryService;

        public SessionService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }

        public Session CreateSession(Principal principal)
        {
            Session session = new Session();
            session.Principal = principal;

            this._repositoryService.AddOnCommit<Session>(Constants.Db.AppCoreDbContextNames.Core,session);

            return session;
        }
    }
}
