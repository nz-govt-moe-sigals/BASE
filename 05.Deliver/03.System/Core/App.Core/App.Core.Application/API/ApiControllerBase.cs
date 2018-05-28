//DUMB APPROACH IS TO USE DbContext in base class, rather than DI.
//using App.Core.Application;
//using App.Core.Infrastructure.Db.Context;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using App.Core.Infrastructure.Services;

//namespace App.Core.Application.API.Controllers
//{
//    public abstract class ApiControllerBase : ApiController
//    {
//        protected readonly IPrincipalService _principalService;

//        protected ApiControllerBase(IPrincipalService principalService)
//        {
//            _principalService = principalService;
//        }

//        // Validate to ensure the necessary scopes are present.
//        protected void HasRequiredScopes(String permission)
//        {
//            //The base method just verifies scope
//            if (!_principalService.HasRequiredScopes(permission))
//            {
//                // this controller still has to raise an exception
//                throw new HttpResponseException(new HttpResponseMessage
//                {
//                    StatusCode = HttpStatusCode.Unauthorized,
//                    ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
//                });
//            }
//        }

//    }

//    public abstract class DataApiControllerBase : ApiControllerBase {
//        protected AppCoreDbContext _appCoreDbContext;

//        protected DataApiControllerBase(IPrincipalService principalService):base(principalService)
//        {
//            _appCoreDbContext = new AppCoreDbContext();
//            _appCoreDbContext.Database.Log = Console.Write;
//        }

//        protected override void Dispose(bool disposing)
//        {
//            var appCoreDbContext = AppServiceLocator.Current.GetInstance<AppCoreDbContext>();

//            bool shouldSave1 = appCoreDbContext.ChangeTracker.HasChanges();
//            bool shouldSave2 = _appCoreDbContext.ChangeTracker.HasChanges();
//            if (shouldSave1 != shouldSave2)
//            {
//                throw new Exception("DbContext!=DbContext!");
//            }
//            //if (shouldSave2)
//            //{
//            //    _appCoreDbContext.SaveChanges();
//            //}
//            if (_appCoreDbContext != null)
//            {
//                _appCoreDbContext.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

