/*
 * Title: Project.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-13
 * Purpose: To provide an easily jsonable representation of a project, for database storage
 * AI Used: No AI used for this class.
*/

#region Namespace Definition

namespace FinalAssignment.Models
{
    /// <summary>
    /// Provides an easily jsonable representation of a project, for database storage.
    /// </summary>
    class PackagedProject
    {
        #region Instance Properties and Elements

        /// <summary>
        /// Header contains a project name and a project length.
        /// </summary>
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Timeline contains a key value pair for each note. A note gets a name int, and a location (as a millisecond) int.
        /// </summary>
        public Dictionary<int, int> Timeline { get; set; } = new Dictionary<int, int>();

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default Constructor is - This class is primarily a data container, so defaults should not be set.
        /// </summary>
        public PackagedProject() { }


        /// <summary>
        /// Packages the specified project.
        /// </summary>
        /// <param name="project">The project to package.</param>
        public PackagedProject(Project project)
        {
            Package(project);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Packages this packaged project based on the specified project.
        /// </summary>
        /// <param name="project">The project to package.</param>
        public void Package(Project project)
        {
            // Header
            Header.Add("ProjectName", project.Name);
            Header.Add("ProjectLength", project.TimelineLength.ToString());

            // Timeline
            PackageAllNotes(project.Timeline);
            
        }

        /// <summary>
        /// Adds all project notes to timeline dict.
        /// </summary>
        /// <param name="timeline">The timeline to read from.</param>
        private void PackageAllNotes(List<Note> timeline)
        {
            foreach (Note note in timeline)
            {
                Timeline.Add(note.NoteNumber, note.TimelineLocation);
            }
        }

        #endregion
    }
}

#endregion