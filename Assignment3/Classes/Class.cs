/*
 * Title: Class.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-01
 * Purpose: To provide a static list of instantiated classes
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region Namespace Definition

namespace Assignment3
{

    /// <summary>
    /// Represents a Dungeons and Dragons class, containing a name and a description.
    /// Instantiated classes can be found at Class.Classes, a static List collection.
    /// 
    /// A class can be indexed by name through the static method Class.FindByName(),
    /// or by the class directly through Class.FindByReference().
    /// </summary>
    internal class Class
    {

        #region Static Variables

        public static List<Class> Classes = new List<Class>();

        #endregion

        #region Instance Propeties

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - Simply sets a default Name and Description for this class.
        /// </summary>
        public Class()
        {
            Name = "";
            Description = "";
        }

        /// <summary>
        /// Parameterized constructor - Sets Name and Description based on parameters.
        /// </summary>
        public Class(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Searches through static list of instantiated classes for a class with a matching name.
        /// If a match cannot be found, a new Class will be returned.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Class FindByName(string name)
        {
            foreach (Class storedClass in Classes)
            {
                if (storedClass.Name == name) { return storedClass; }
            }
            return new Class();
        }

        #endregion
    }
}

#endregion
