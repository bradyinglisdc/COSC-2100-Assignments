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

        /// <summary>
        /// Reads the packaged project into a new Project and returns the result.
        /// </summary>
        /// <param name="projectID">The ID of the project.</param>
        /// <param name="userID">The ID of the owner.</param>
        /// <returns>The unpackaged project.</returns>
        public Project Unpackage(int projectID, int userID)
        {
            // An error could happen if data can't be parsed, i.e. someone manually messed with the database.
            try
            {
                // Set identification values
                Project unpackagedProject = new Project()
                {
                    ProjectID = projectID,
                    UserID = userID
                };

                // Unpackage headers and timeline then return
                UnpackageHeaders(unpackagedProject);
                UnpackageTimeline(unpackagedProject);
                return unpackagedProject;
            }

            catch (Exception ex)
            {
                throw new Exception($"Unpackage error: {ex.Message}");
            }

        }

        /// <summary>
        /// Sets all header values for a project based on this instance.
        /// </summary>
        /// <param name="unpackagedProject">The project to add headers to.</param>
        private void UnpackageHeaders(Project unpackagedProject)
        {
            unpackagedProject.Name = Header["ProjectName"];
            unpackagedProject.TimelineLength = int.Parse(Header["ProjectLength"]);
        }

        /// <summary>
        /// Creaetes a note for every note description in the unpackaged timeline, adding it to 
        /// a packaged timeline
        /// </summary>
        /// <param name="unpackagedProject">The project to add a timeline to.</param>
        private void UnpackageTimeline(Project unpackagedProject)
        {
            // Add each note in the timeline
            foreach (KeyValuePair<int, int> unpackagedNote in Timeline)
            {
                // Get the parent note. Throw an error if it was null
                Note? parentNote = Note.GetByNoteNumber(unpackagedNote.Key);
                if (parentNote == null) { throw new Exception("Could not read a note in your project."); }

                // Clone the note
                Note note = new Note()
                {
                    ParentNote = parentNote,
                    CurrentNote = parentNote.CurrentNotePlayer,
                    NoteNumber = parentNote.NoteNumber,
                    TimelineLocation = unpackagedNote.Value
                };

                // Add the note to the packaged project timeline
                unpackagedProject.Timeline.Add(note);
            }
        }

        #endregion
    }
}

#endregion