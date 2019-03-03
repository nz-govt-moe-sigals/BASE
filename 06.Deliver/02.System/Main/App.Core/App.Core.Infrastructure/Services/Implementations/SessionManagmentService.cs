using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Shared.Models.Entities;

namespace App.Core.Infrastructure.Services.Implementations
{

    /// <summary>
    /// Only 1 class
    /// </summary>
    public class SessionManagmentService : ISessionManagmentService

    {
        private readonly IRepositoryService _repositoryService;
        private readonly ISessionService _sessionService;
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly IPrincipalManagmentService _principalManagmentService;

        public SessionManagmentService(IRepositoryService repositoryService,
            ISessionService sessionService,
            IPrincipalManagmentService principalManagmentService)
        {
            this._repositoryService = repositoryService;
            _sessionService = sessionService;
            _semaphoreSlim = new SemaphoreSlim(1);
            _principalManagmentService = principalManagmentService;
        }


        public void SaveSessionOperationAsync(SessionOperation sessionOperation, IPrincipalService principalService)
        {
            var principal = new PrincipalUserSession
            {
                UniqueSessionIdentifier = principalService.UniqueSessionIdentifier,
                CurrentPrincipalIdentifierGuid = principalService.CurrentPrincipalIdentifierGuid,
                IsAuthenticated = principalService.IsAuthenticated
            };
            HostingEnvironment.QueueBackgroundWorkItem(x => { SaveTheSession(sessionOperation, principal); });
        }


        private void SaveTheSession(SessionOperation sessionOperation, PrincipalUserSession principalService)
        {
            if (!principalService.IsAuthenticated)
            {
                _repositoryService.AddOnCommit(AppCoreDbContextNames.Core, sessionOperation);
                _repositoryService.SaveChanges(AppCoreDbContextNames.Core);
                return;
            }
            AddSession(sessionOperation, principalService);

        }

        private void AddSession(SessionOperation sessionOperation, PrincipalUserSession principalService)
        {
            var session = _sessionService.Get(principalService.UniqueSessionIdentifier);
            if (session == null)
            {
                if(!principalService.CurrentPrincipalIdentifierGuid.HasValue) { return; }
                try
                {
                    _semaphoreSlim.Wait();
                    session = _sessionService.Get(principalService.UniqueSessionIdentifier);
                    if (session == null)
                    {
                        var principal = _principalManagmentService.Get(principalService.CurrentPrincipalIdentifierGuid.Value);
                        session = _sessionService.Create(principal, principalService.UniqueSessionIdentifier);
                        session.Operations.Add(sessionOperation);
                        _repositoryService.SaveChanges(AppCoreDbContextNames.Core);
                        return;
                    }
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }

            sessionOperation.SessionFK = session.Id;
            _repositoryService.AddOnCommit(AppCoreDbContextNames.Core, sessionOperation);
            _repositoryService.SaveChanges(AppCoreDbContextNames.Core);


            //return session;
        }

        protected class PrincipalUserSession
        {
            public Guid? CurrentPrincipalIdentifierGuid { get; set; }

            public string UniqueSessionIdentifier { get; set; }

            public bool IsAuthenticated { get; set; }
        }

    }
}
