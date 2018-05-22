using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module02.Shared.Models.Enums
{
    public enum  ExampleEnum
    {
        // Ensure all Model enums start with the folowing states.
        // Comment out those not needed, but continue numeration as
        // if they are they. 

        // An error state (means developer has not addressed the enum).
        Undefined = 0,
        // Actually don't know and can't answer it at this point (valid fallback in some cases)
        //Unspecified is the same thing (maybe it should be called this...still mulling that over).
        Unknown = 1,
        // End users may not want to disclose race, religion, gender, etc.
        Undisclosed =2,
    }
}


