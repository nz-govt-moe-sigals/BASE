using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated
{
    public class SifContactNameDto
    {
        public SifContactNameDto()
        {

        }

        public SifContactNameDto(string fullName)
        {
            SetFullName(fullName);
        }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string FullName { get; set; }

        public void SetFullName(string fullName)
        {
            FullName = fullName;
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                var namesplit = fullName.Split(new [] { ' ' }, 2);
                if (namesplit.Length == 1)
                {
                    FamilyName = namesplit[0];
                }
                else
                {
                    GivenName = namesplit[0];
                    FamilyName = namesplit[1];
                }
            }
        }
    }
}
