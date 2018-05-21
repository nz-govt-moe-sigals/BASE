namespace App.Module02.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.Base;
    using App.Module02.Infrastructure.Constants.Db;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.Imports;

    class XXX
    {
        public string Key
        {
            get; set;
        }
    }
    public class StudentRawImportService : AppModuleServiceBase, IStudentRawImportService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ISchoolCsvImporterService _schoolCsvImporterService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly INameParsingService _nameParsingService;

        List<SchoolAuthority> _schoolAuthority;
        List<SchoolDecile> _schoolDecile;
        List<SchoolDefinition> _schoolDefinition;
        List<SchoolEducationRegion> _schoolEducationRegion;
        List<SchoolGender> _schoolGender;
        List<SchoolGeneralElectorate> _schoolGeneralElectorate;
        List<SchoolMaoriElectorate> _schoolMaoriElectorate;
        List<SchoolMinistryOfEducationLocalOffice> _schoolMinistryOfEducationLocalOffice;
        List<SchoolRegionalCouncil> _schoolRegionalCouncil;
        List<SchoolTerritorialAuthorityWithAucklandLocalBoard> _schoolTerritorialAuthorityWithAucklandLocalBoard;
        List<SchoolType> _schoolTypes;


        public StudentRawImportService(IRepositoryService repositoryService, ISchoolCsvImporterService schoolCsvImporterService, IUnitOfWorkService unitOfWorkService, INameParsingService nameParsingService)
        {
            this._repositoryService = repositoryService;
            this._schoolCsvImporterService = schoolCsvImporterService;
            this._unitOfWorkService = unitOfWorkService;
            this._nameParsingService = nameParsingService;
        }

        public void Do(Stream stream)
        {

            this._unitOfWorkService.Commit();

            this.PrepareKnownReferenceDataLists();

            int counter = 0;
            int schoolBaseCounter = 1000;
            int principalBaseCounter = schoolBaseCounter * 200;

            SchoolDescriptionRaw[] schoolDescriptionRawSet = this._schoolCsvImporterService.Import(stream);


            try
            {
                BuildReferenceData(schoolDescriptionRawSet);
            }
            catch (System.Exception e)
            {
                throw e;
            }


            this._unitOfWorkService.Commit();



            foreach (SchoolDescriptionRaw schoolDescriptionRaw in schoolDescriptionRawSet) //  SchoolSeedingData.data.Take(10))
            {
                counter++;

                int schoolId = (int)decimal.Parse(schoolDescriptionRaw.SchoolID);

                Guid schoolGuid = (schoolBaseCounter + schoolId).ToGuid();

                Guid principalGuid = (principalBaseCounter + schoolId).ToGuid();


                //Create the Org backing the School:
                var esatablishmentOrganisation = BuildEstablishmentOrganisation(schoolDescriptionRaw, schoolGuid);

                var establishmentOrganisationAlias = BuildEstablishmentOrganisationName(schoolDescriptionRaw, schoolGuid, esatablishmentOrganisation);

                //schoolBody.PreferredName = schoolName;

                ////Add a chanel to the Org:
                var establishmentOrganisationChannel = BuildEstablishmentOrganisationChannel(schoolDescriptionRaw, schoolGuid);

                ////Ensure the Channel is part of the Org:
                //if (!schoolBody.Channels.Any(x => x.Id == orgChannel.Id))
                //{
                //    schoolBody.Channels.Add(orgChannel);
                //}




                BuildEducationEstablishmentOrganisationClaims(schoolDescriptionRaw, esatablishmentOrganisation);

                BuildEducationEstablishmentOrganisationProperties(schoolDescriptionRaw, esatablishmentOrganisation);

                ////Now do the principal:
                var principal = BuildEducationEstablishmentPrincipal(schoolDescriptionRaw, principalGuid);

                BuildEducationEstablishment(schoolDescriptionRaw, schoolGuid, esatablishmentOrganisation, principal);

                //this._unitOfWorkService.Commit(Constants.Db.AppModuleDbContextNames.Default);
            }
        }

        private int BuildReferenceData(SchoolDescriptionRaw[] schoolDescriptionRaw)
        {
            int score = 0;
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolAuthority>(schoolDescriptionRaw.Select(x => x.Authority).Distinct().ToArray(), this._schoolAuthority);
            score += BuildReferenceData_EducationEstablishmentAuthority<SchoolDecile>(schoolDescriptionRaw.Select(x => x.Decile).Distinct().ToArray(), this._schoolDecile);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolDefinition>(schoolDescriptionRaw.Select(x => x.Definition).Distinct().ToArray(), this._schoolDefinition);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolEducationRegion>(schoolDescriptionRaw.Select(x => x.EducationRegion).Distinct().ToArray(), this._schoolEducationRegion);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolGender>(schoolDescriptionRaw.Select(x => x.GenderofStudents).Distinct().ToArray(), this._schoolGender);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolGeneralElectorate>(schoolDescriptionRaw.Select(x => x.GeneralElectorate).Distinct().ToArray(), this._schoolGeneralElectorate);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolMaoriElectorate>(schoolDescriptionRaw.Select(x => x.MaoriElectorate).Distinct().ToArray(), this._schoolMaoriElectorate);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolMinistryOfEducationLocalOffice>(schoolDescriptionRaw.Select(x => x.MinistryofEducationLocalOffice).Distinct().ToArray(), this._schoolMinistryOfEducationLocalOffice);
            score+= BuildReferenceData_EducationEstablishmentAuthority<SchoolRegionalCouncil>(schoolDescriptionRaw.Select(x => x.RegionalCouncil).Distinct().ToArray(), this._schoolRegionalCouncil);
            score += BuildReferenceData_EducationEstablishmentAuthority<SchoolTerritorialAuthorityWithAucklandLocalBoard>(schoolDescriptionRaw.Select(x => x.TerritorialAuthoritywithAucklandLocalBoard).Distinct().ToArray(), this._schoolTerritorialAuthorityWithAucklandLocalBoard);
            //score += BuildReferenceData_EducationEstablishmentAuthority<SchoolType>(schoolDescriptionRaw.Select(x => x.Type).Distinct().ToArray(), _schoolAuthority);
            return score;
        }


        private int BuildReferenceData_EducationEstablishmentAuthority<T>(string[] srcRecords, IEnumerable<IHasText> _source)
            where T: TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase,new()
        {


            var missing = GetMissingRecords<IHasText>(srcRecords, _source);

            foreach (string tmp in missing )
            {
                var newRec = new T
                {
                    Enabled = true,
                    Text = tmp,
                };
                this._repositoryService.AddOnCommit<T>(Constants.Db.AppModuleDbContextNames.Default, newRec);
            }

            return missing.Count();

        }

 


        private string[] GetMissingRecords<T>(string[] inSource, IEnumerable<T> inDb) where T : IHasText
        {
            var notYetInDb = inSource.Where(x => !inDb.Any(y => y.Text == x)).ToArray();
            return notYetInDb;
        }


        private void BuildReferenceData_EducationEstablishmentGender(SchoolDescriptionRaw[] schoolDescriptionRaw)
        {
            var tmp = schoolDescriptionRaw.Select(x => new
            {
                Key = x.GenderofStudents
            }).Distinct();
        }

        private static void BuildEducationEstablishmentOrganisationProperties(SchoolDescriptionRaw schoolDescriptionRaw, Body esatablishmentOrganisation)
        {
            if (esatablishmentOrganisation.Properties.SingleOrDefault(x => x.Key == OrganisationPropertyKeys.Longitude) == null)
            {
                esatablishmentOrganisation.Properties.Add(new BodyProperty
                {
                    TenantFK = 1.ToGuid(),
                    Key = OrganisationPropertyKeys.Longitude,
                    Value = schoolDescriptionRaw.Longitude
                });
            }
            if (esatablishmentOrganisation.Properties.SingleOrDefault(x => x.Key == OrganisationPropertyKeys.Latitude) == null)
            {
                esatablishmentOrganisation.Properties.Add(new BodyProperty
                {
                    TenantFK = 1.ToGuid(),
                    Key = OrganisationPropertyKeys.Latitude,
                    Value = schoolDescriptionRaw.Latitude
                });
            }
        }

        private static void BuildEducationEstablishmentOrganisationClaims(SchoolDescriptionRaw schoolDescriptionRaw, Body esatablishmentOrganisation)
        {
//Add claims
            if (esatablishmentOrganisation.Claims.SingleOrDefault(x => x.Key == OrganisationPropertyKeys.Longitude) == null)
            {
                esatablishmentOrganisation.Claims.Add(new BodyClaim
                {
                    TenantFK = 1.ToGuid(),
                    Authority = "Foo",
                    AuthoritySignature = "Bar",
                    Key = OrganisationPropertyKeys.Longitude,
                    Value = schoolDescriptionRaw.Longitude
                });
            }

            if (esatablishmentOrganisation.Claims.SingleOrDefault(x => x.Key == OrganisationPropertyKeys.Latitude) == null)
            {
                esatablishmentOrganisation.Claims.Add(new BodyClaim
                {
                    TenantFK = 1.ToGuid(),
                    Authority = "Foo",
                    AuthoritySignature = "Bar",
                    Key = OrganisationPropertyKeys.Latitude,
                    Value = schoolDescriptionRaw.Latitude
                });
            }
        }


        private Body BuildEstablishmentOrganisation(SchoolDescriptionRaw schoolDescriptionRaw, Guid schoolGuid)
        {
            var educationEstablishmentOrganisation = new Body
            {
                Id = schoolGuid,
                TenantFK = 1.ToGuid(),
                RecordState = RecordPersistenceState.Active,
                CategoryFK = 1.ToGuid(),
                Type = BodyType.Organisation,
                Name = schoolDescriptionRaw.Name
            };

            //Add a Name to the Org, then make it Preferred:

            //Save after saving BodyName:
            this._repositoryService.AddOrUpdate<Body>(Constants.Db.AppModuleDbContextNames.Default, p => p.Id, educationEstablishmentOrganisation);
            return educationEstablishmentOrganisation;
        }

        private BodyAlias BuildEstablishmentOrganisationName(SchoolDescriptionRaw schoolDescriptionRaw, Guid schoolGuid, Body schoolBody)
        {
            var educationEstablishmentOrganisationName = new BodyAlias
            {
                Id = schoolGuid,
                TenantFK = 1.ToGuid(),
                OwnerFK = schoolBody.Id,
                Title = schoolDescriptionRaw.Name,
                Name = schoolDescriptionRaw.Name
            };
            this._repositoryService.AddOrUpdate<BodyAlias>(Constants.Db.AppModuleDbContextNames.Default, p => p.Id,
                educationEstablishmentOrganisationName);

            return educationEstablishmentOrganisationName;
        }


        private BodyChannel BuildEstablishmentOrganisationChannel(SchoolDescriptionRaw schoolDescriptionRaw, Guid schoolGuid)
        {
            var educationEstablishmentOrganisationChannel = new BodyChannel
            {
                Id = schoolGuid,
                TenantFK = 1.ToGuid(),
                OwnerFK = schoolGuid,
                Title = OrganisationPropertyKeys.OfficePhone,
                Protocol = BodyChannelType.Landline,
                Address = schoolDescriptionRaw.Telephone
            };

            this._repositoryService.AddOrUpdate<BodyChannel>(Constants.Db.AppModuleDbContextNames.Default, p => p.Id,
                educationEstablishmentOrganisationChannel);

            return educationEstablishmentOrganisationChannel;
        }




        private Body BuildEducationEstablishmentPrincipal(SchoolDescriptionRaw schoolDescriptionRaw, Guid principalGuid)
        {
            var parsedNames = this._nameParsingService.Parse(schoolDescriptionRaw.Principal, singleNameIsLastName: true);

            var principal = new Body
            {
                Id = principalGuid,
                TenantFK = 1.ToGuid(),
                Type = BodyType.Person,
                CategoryFK = 2.ToGuid(),

                //Name = schoolDescriptionRaw.Principal,
                Prefix = parsedNames.Prefix,
                GivenName = parsedNames.Givenname,
                MiddleNames = parsedNames.Middlenames,
                SurName = parsedNames.Surname,
                Suffix = parsedNames.Suffix
            };

            this._repositoryService.AddOrUpdate<Body>(Constants.Db.AppModuleDbContextNames.Default, p => p.Id,
                principal);

            return principal;
        }





        private void BuildEducationEstablishment(SchoolDescriptionRaw schoolDescriptionRaw, Guid schoolGuid,
            Body esatablishmentOrganisation, Body principal)
        {
            //Make a school with both Org and Principal:

            var educationEstablishment = new EducationOrganisation
            {
                Id = schoolGuid,
                TenantFK = 1.ToGuid(),
                Type = SchoolEstablishmentType.School,
                Key = schoolDescriptionRaw.Name,
                OrganisationFK = esatablishmentOrganisation.Id,
                PrincipalFK = principal.Id
            };

            this._repositoryService.AddOrUpdate<EducationOrganisation>(Constants.Db.AppModuleDbContextNames.Default,
                p => p.Id, educationEstablishment);
        }

        private void PrepareKnownReferenceDataLists()
        {
            this._schoolAuthority = this._repositoryService.GetQueryableSet<SchoolAuthority>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolDecile = this._repositoryService.GetQueryableSet<SchoolDecile>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolDefinition = this._repositoryService.GetQueryableSet<SchoolDefinition>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolEducationRegion = this._repositoryService.GetQueryableSet<SchoolEducationRegion>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolGender = this._repositoryService.GetQueryableSet<SchoolGender>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolGeneralElectorate = this._repositoryService.GetQueryableSet<SchoolGeneralElectorate>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolMaoriElectorate = this._repositoryService.GetQueryableSet<SchoolMaoriElectorate>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolMinistryOfEducationLocalOffice = this._repositoryService.GetQueryableSet<SchoolMinistryOfEducationLocalOffice>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolRegionalCouncil = this._repositoryService.GetQueryableSet<SchoolRegionalCouncil>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolTerritorialAuthorityWithAucklandLocalBoard = this._repositoryService.GetQueryableSet<SchoolTerritorialAuthorityWithAucklandLocalBoard>(Constants.Db.AppModuleDbContextNames.Default).ToList();
            this._schoolTypes = this._repositoryService.GetQueryableSet<SchoolType>(Constants.Db.AppModuleDbContextNames.Default).ToList();
        }


    }
}