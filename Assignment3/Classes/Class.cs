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

        /// <summary>
        /// Static list of all Class instances.
        /// </summary>
        public static List<Class> Classes = new List<Class>();

        #endregion

        #region Instance Propeties

        /// <summary>
        /// The name of this class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this class.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The HPDice for this class.
        /// </summary>
        public int HPDice { get; set; }

        /// <summary>
        /// The URI to this classes symbol image file.
        /// </summary>
        public string? ClassSymbolURI { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - Simply sets a default Name and Description for this class.
        /// </summary>
        public Class()
        {
            Name = Constants.DefaultClass;
            Description = Constants.DefaultClassDescription;
            HPDice = Constants.DefaultHPDice;
        }

        /// <summary>
        /// Parameterized constructor - Sets Name, Description and HP Dice based on parameters.
        /// </summary>
        /// <param name="name">The name of this class.</param>
        /// <param name="description">The description of this class.</param>
        /// <param name="hpDice">The HP dice of this class.</param>
        /// <param name="classSymbolURI">The URI to the symbol of this class</param>
        public Class(string name, string description, int hpDice, string classSymbolURI)
        {
            Name = name;
            Description = description;
            HPDice = hpDice;
            ClassSymbolURI = classSymbolURI;
            Classes.Add(this);
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Searches through static list of instantiated classes for a class with a matching name.
        /// If a match cannot be found, the first class.
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

        /// <summary>
        /// Returns a list of the names of all instantiated classes.
        /// </summary>
        /// <returns>List of the name of all instantiated classes.</returns>
        public static List<string> GetClassNames()
        {
            List<string> classNames = new List<string>();
            foreach (Class currentClass in Classes)
            {
                if (currentClass.Name != null) { classNames.Add(currentClass.Name); }
    
            }
            return classNames;
        }

        #endregion
    }
}

#endregion
