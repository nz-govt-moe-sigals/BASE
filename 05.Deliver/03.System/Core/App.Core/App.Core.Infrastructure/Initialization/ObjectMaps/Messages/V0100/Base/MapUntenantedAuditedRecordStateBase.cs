using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base
{
    public abstract class MapUntenantedAuditedRecordStateBase<TDto, TEntity>
    where TEntity : UntenantedAuditedRecordStatedTimestampedNoIdEntityBase
    {
        protected void MapBase(IMappingExpression<TDto, TEntity> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
