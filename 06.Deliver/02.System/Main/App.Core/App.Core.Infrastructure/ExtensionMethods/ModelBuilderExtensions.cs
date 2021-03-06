﻿using App.Core.Infrastructure.Constants.Db;
using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class ModelBuilderExtensions
    {

        public static void DefineTenantFK<T>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK
        {
            modelBuilder.Entity<T>()
                .Property(x => x.TenantFK)
                .HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_TenantFK")
                    {
                        IsUnique = false
                    }))
                .IsRequired()
                ;
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //modelBuilder.Entity<T>()
            //    .HasRequired(x => x.Tenant)
            //    .WithMany()
            //    .HasForeignKey(x => x.TenantFK)
            //    .WillCascadeOnDelete(false);

        }

        public static void DefineCustomId<T, TId>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>
            where TId : struct
        {
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<T>()
                .Property(x => x.Id)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }



        public static void DefineUniqueKey<T>(this DbModelBuilder modelBuilder, ref int order, int size = TextFieldSizes.X64, Func<int, int> injectedPropertyDefs = null)
    where T : class, IHasKey
        {
            modelBuilder.Entity<T>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(size)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_Key") { IsUnique = true }))
                .IsRequired()
                ;
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }


        public static void DefineNonUniqueKey<T>(this DbModelBuilder modelBuilder, ref int order, int size = TextFieldSizes.X64, Func<int, int> injectedPropertyDefs = null)
where T : class, IHasKey
        {
            modelBuilder.Entity<T>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(size)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_Key") { IsUnique = false }))
                .IsRequired()
                ;
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }


        public static void DefineTimestampedAuditedRecordStated<T>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
        where T : class, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            //3:
            modelBuilder.Entity<T>()
                .Property(x => x.Timestamp)
                .IsConcurrencyToken()
                .IsRowVersion()
                .HasColumnOrder(order++)
                //.IsRequired()
                ;
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //4:
            modelBuilder.Entity<T>()
                .Property(x => x.RecordState)
                .HasColumnOrder(order++)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_RecordState")
                    {
                        IsUnique = false
                    }))
                ;
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //5:
            modelBuilder.Entity<T>()
                .Property(x => x.CreatedOnUtc)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //6:
            modelBuilder.Entity<T>()
                .Property(x => x.CreatedByPrincipalId)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.GuidStringLength)
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //7:
            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedOnUtc)
                .HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_LastModifiedOnUtc")
                    {
                        IsUnique = false
                    }))
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //8:
            modelBuilder.Entity<T>()
                .Property(x => x.LastModifiedByPrincipalId)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.GuidStringLength)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_LastModifiedByPrincipalId")
                    {
                        IsUnique = false
                    }))
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //9:
            modelBuilder.Entity<T>()
                .Property(x => x.DeletedOnUtc)
                .HasColumnOrder(order++)
                .IsOptional();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //10:
            modelBuilder.Entity<T>()
                .Property(x => x.DeletedByPrincipalId)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.GuidStringLength)
                .IsOptional();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

        }
        public static void DefineRequiredEnabled<T>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
    where T : class, IHasEnabled
        {
            modelBuilder.Entity<T>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();
        }

        public static void DefineTitleAndDescription<T>(this DbModelBuilder modelBuilder, ref int order, int fieldSize= TextFieldSizes.X64, bool applyTitleIndex=true, bool descriptionIsMaxLength=false, Func<int, int> injectedPropertyDefs = null)
    where T : class, IHasTitleAndDescription
        {

            modelBuilder.Entity<T>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(fieldSize)
                //.HasColumnAnnotation("Index",
                //    new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_Title")
                //    {
                //        IsUnique = false
                //    }))
                .IsRequired()
                ;

            if (applyTitleIndex)
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Title)
                    .HasColumnAnnotation("Index",
                        new IndexAnnotation(new IndexAttribute($"IX_{typeof(T).Name}_Title")
                        {
                            IsUnique = false
                        }))
                    .IsRequired()
                    ;
            }
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            if (descriptionIsMaxLength)
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Description)
                    .HasColumnOrder(order++)
                    .IsMaxLength()
                    .IsOptional();
            }
            else
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.Description)
                    .HasColumnOrder(order++)
                    .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X2048)
                    .IsOptional();

            }
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }

        public static void DefineReferenceData<T>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasReferenceData
        {
            //12:
            modelBuilder.DefineRequiredEnabled<T>(ref order);
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //-- Might inject keys here...(if order == 12...)

            //13:
            modelBuilder.DefineTitleAndDescription<T>(ref order,fieldSize: TextFieldSizes.X64,applyTitleIndex: true, descriptionIsMaxLength: false);

        }


        public static void DefineDisplayableReferenceData<T>(this DbModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasDisplayableReferenceData
        {

            modelBuilder.DefineReferenceData<T>(ref order, injectedPropertyDefs);

            //14:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }

            //15:
            modelBuilder.Entity<T>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsOptional();
            if (injectedPropertyDefs != null) { order = injectedPropertyDefs.Invoke(order); }
        }

        //        public static void DefineStandard(this DbModelBuilder modelBuilder, Expression<Func<TDto, object>> func)
        //        {
        //            ((MemberExpression)func.Body).Member.MemberType
        //            Func<TDto, object> p;
        //            p.)
        //            func.
        //            modelBuilder.Entity<Course>()
        //.Property(x => x.Key)
        //.HasColumnOrder(order++)
        //.IsRequired();

        //        }


    }
}
