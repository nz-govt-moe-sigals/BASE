//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Core.Infrastructure.Validator
//{
//    using App.Core.Shared.Models.Configuration;

//    public class AadApplicationRegistrationInformationValidator
//    {
//        bool Validate(AadApplicationRegistrationInformation source)
//        {
//            if (source == null)
//            {
//                throw new ValidationError($"AadApplicationRegistrationInformation is not set.");
//            }
//            if (string.IsNullOrWhiteSpace(source.ClientSecret))
//            {
//                throw new ValidationError("Azure ApplicationId/ClientId not set.");
//            }
//            if (string.IsNullOrWhiteSpace(source.ClientSecret))
//            {
//                throw new ValidationError("Azure ApplicationId/ClientId not set.");
//            }
//        }
//    }
//}
