using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Core.Application.Services.Implementations
{
    public class UserProfileService : IUserProfileService
    {
        private readonly string _dbContextIdentifier;
        protected readonly IRepositoryService RepositoryService;
        protected readonly IPrincipalService PrincipalService;

        public UserProfileService(IRepositoryService repositoryService, IPrincipalService principalService,
            IDiagnosticsTracingService diagnosticsTracingService)
        {
            RepositoryService = repositoryService;
            PrincipalService = principalService;
            _dbContextIdentifier = AppCoreDbContextNames.Core; 
        }


        public void UpdateUserProfile(UserProfileDto dto)
        {
            if(dto == null) { return; }
            var value = Mapper.Map<UserProfileDto, Principal>(dto);
            UpdateUserProfile(value);
        }

        public void UpdateUserProfile(Principal entity)
        {
            if (entity == null) { return; }
            var current = RepositoryService.GetQueryableSingle<Principal>(_dbContextIdentifier,
                x => x.Id == PrincipalService.CurrentPrincipalIdentifierGuid.Value).FirstOrDefault();
            if (current == null) { throw new ArgumentException("Somehow a User does not exist"); }

            Mapper.Map(entity, current);
            RepositoryService.UpdateOnCommit(_dbContextIdentifier, current);
        }

        public UserProfileDto GetUserProfile()
        {
            var current = RepositoryService.GetQueryableSingle<Principal>(_dbContextIdentifier,
                x => x.Id == PrincipalService.CurrentPrincipalIdentifierGuid.Value).FirstOrDefault();
            return Mapper.Map<Principal, UserProfileDto>(current);
        }

    }
}
