namespace App.Module2.Infrastructure.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.Imports;

    public class StudentRawImportService : IStudentRawImportService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ISchoolCsvImporterService _schoolCsvImporterService;
        private readonly IUnitOfWorkService _unitOfWorkService;

        public StudentRawImportService(IRepositoryService repositoryService, ISchoolCsvImporterService schoolCsvImporterService, IUnitOfWorkService unitOfWorkService)
        {
            this._repositoryService = repositoryService;
            this._schoolCsvImporterService = schoolCsvImporterService;
            this._unitOfWorkService = unitOfWorkService;
        }
        public void Do(Stream stream)
        {

            this._unitOfWorkService.Commit();

            int counter = 0;
            int schoolBaseCounter = 1000;
            int principalBaseCounter = schoolBaseCounter * 200;

            foreach (SchoolDescriptionRaw schoolDescriptionRaw in this._schoolCsvImporterService.Import(stream)) //  SchoolSeedingData.data.Take(10))
            {
                counter++;

                int schoolId = (int)decimal.Parse(schoolDescriptionRaw.SchoolID);

                Guid schoolGuid = (schoolBaseCounter + schoolId).ToGuid();

                Guid principalGuid = (principalBaseCounter + schoolId).ToGuid();


                //Create the Org backing the School:
                var schoolBody = new Body
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
                this._repositoryService.AddOrUpdate<Body>(Constants.Db.AppModule2DbContextNames.Module2, p => p.Id, schoolBody);

                var schoolName = new BodyAlias
                {
                    Id = schoolGuid,
                    TenantFK = 1.ToGuid(),
                    OwnerFK = schoolBody.Id,
                    Title = schoolDescriptionRaw.Name,
                    Name = schoolDescriptionRaw.Name
                };
                this._repositoryService.AddOrUpdate<BodyAlias>(Constants.Db.AppModule2DbContextNames.Module2, p => p.Id, schoolName);

                //schoolBody.PreferredName = schoolName;



                ////Add a chanel to the Org:
                var orgChannel = new BodyChannel
                {
                    Id = schoolGuid,
                    TenantFK = 1.ToGuid(),
                    OwnerFK = schoolGuid,
                    Title = "Office Phone",
                    Protocol = BodyChannelType.Landline,
                    Address = schoolDescriptionRaw.Telephone
                };
                this._repositoryService.AddOrUpdate<BodyChannel>(Constants.Db.AppModule2DbContextNames.Module2, p => p.Id, orgChannel);

                ////Ensure the Channel is part of the Org:
                //if (!schoolBody.Channels.Any(x => x.Id == orgChannel.Id))
                //{
                //    schoolBody.Channels.Add(orgChannel);
                //}




                //Add claims
                if (schoolBody.Claims.SingleOrDefault(x => x.Key == "Longitude") == null)
                {
                    schoolBody.Claims.Add(new BodyClaim { TenantFK = 1.ToGuid(), Authority = "Foo", AuthoritySignature = "Bar", Key = "Longitude", Value = schoolDescriptionRaw.Longitude });
                }
                if (schoolBody.Claims.SingleOrDefault(x => x.Key == "Latitude") == null)
                {
                    schoolBody.Claims.Add(new BodyClaim { TenantFK = 1.ToGuid(), Authority = "Foo", AuthoritySignature = "Bar", Key = "Latitude", Value = schoolDescriptionRaw.Latitude });
                }

                if (schoolBody.Properties.SingleOrDefault(x => x.Key == "Longitude") == null)
                {
                    schoolBody.Properties.Add(new BodyProperty { TenantFK = 1.ToGuid(), Key = "Longitude", Value = schoolDescriptionRaw.Longitude });
                }
                if (schoolBody.Properties.SingleOrDefault(x => x.Key == "Latitude") == null)
                {
                    schoolBody.Properties.Add(new BodyProperty { TenantFK = 1.ToGuid(), Key = "Latitude", Value = schoolDescriptionRaw.Latitude });
                }



                ////Now do the principal:
                var principal = new Body
                {
                    Id = principalGuid,
                    TenantFK = 1.ToGuid(),
                    Type = BodyType.Person,
                    CategoryFK = 2.ToGuid(),
                    Name = schoolDescriptionRaw.Principal
                };

                this._repositoryService.AddOrUpdate<Body>(Constants.Db.AppModule2DbContextNames.Module2, p => p.Id, principal);



                //Make a school with both Org and Principal:
                var school = new EducationOrganisation { Id = schoolGuid, TenantFK = 1.ToGuid(), Type = SchoolEstablishmentType.School, Key = schoolDescriptionRaw.Name, OrganisationFK = schoolBody.Id, PrincipalFK = principal.Id };
                this._repositoryService.AddOrUpdate<EducationOrganisation>(Constants.Db.AppModule2DbContextNames.Module2, p => p.Id, school);


                //this._unitOfWorkService.Commit(Constants.Db.AppModule2DbContextNames.Module2);


            }


            
        }

    }
}