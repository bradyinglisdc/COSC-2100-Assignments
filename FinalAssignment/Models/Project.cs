/*
 * Title: Prokect.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-11
 * Purpose: To provide an organized collection of notes, forming a single project
 * AI Used: AI was used to develop stuff
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region Namespace Definition

namespace FinalAssignment.Models
{
    /// <summary>
    /// A project is a collection of notes, where each note is placed in a conceptual timeline
    /// corresponding to the acutal timeline the user placed them in.
    /// </summary>
    internal class Project
    {
        #region Instance Properties

        /// <summary>
        /// Gets and sets the timeline for this project, containing all project notes.
        /// </summary>
        public List<Note> Timeline { get; set; }

        #endregion

        /// <summary>
        /// Default constructor - just instantiates this project's blank note list.
        /// </summary>
        public Project()
        {
            Timeline = new List<Note>();
        }

        /// <summary>
        /// Parameterized constructor - instantiates this project's pre-populated note list.
        /// </summary>
        /// <param name="timeline"></param>
        public Project(List<Note> timeline)
        {
            Timeline = timeline;
        }
    }
}

#endregion
