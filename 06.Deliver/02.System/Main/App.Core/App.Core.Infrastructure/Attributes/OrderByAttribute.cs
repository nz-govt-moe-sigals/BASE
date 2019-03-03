using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// Attribute put on to Seeding classes to define
    /// in which order to process them.
    /// </summary>
    public class OrderByAttribute : Attribute
    {
        /// <summary>
        /// Optional name of the class.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The instruction to put this class before 
        /// another item of either the specified key name, 
        /// or decorated with one of these attributes, with the Key set.
        /// </summary>
        public string After { get; set; }
    }
}
