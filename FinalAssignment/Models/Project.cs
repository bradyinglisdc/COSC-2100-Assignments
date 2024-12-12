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

        /// <summary>
        /// Gets and sets the length of this project's timeline, in milliseconds
        /// </summary>
        public int TimelineLength { get; set; }

        #endregion

        /// <summary>
        /// Default constructor - just instantiates this project's blank note list.
        /// </summary>
        public Project()
        {
            Timeline = new List<Note>();
        }

        /// <summary>
        /// Parameterized constructor - instantiates this project's pre-populated note list with 
        /// a timeline length
        /// </summary>
        /// <param name="timeline">A pre-populated list of notes.</param>
        /// <param name="timelineLength">The length of this timeline.</param>
        public Project(List<Note> timeline, int timelineLength)
        {
            Timeline = timeline;
            TimelineLength = timelineLength;
        }

        /// <summary>
        /// Parameterized constructor - instantiates this project's blank note list and timeline length
        /// </summary>
        /// <param name="timelineLength">The length of this timeline.</param>
        public Project(int timelineLength)
        {
            Timeline = new List<Note>();
            TimelineLength = timelineLength;
        }
    }
}

#endregion
