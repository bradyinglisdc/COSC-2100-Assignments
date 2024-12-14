/*
 * Title: Project.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-11
 * Purpose: To provide an organized collection of notes, forming a single project
 * AI Used: AI was used to help develop ComposeTimeline(), Play(), NoteExists(), and Fill(). More documentation can be found there.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.IO;
using System.IO.Compression;
using Microsoft.IdentityModel.Tokens;

#endregion

#region Namespace Definition

namespace FinalAssignment.Models
{
    /// <summary>
    /// A project is a collection of notes, where each note is placed in a conceptual timeline
    /// corresponding to the acutal timeline the user placed them in.
    /// </summary>
    public class Project
    {
        #region Constants

        private const string DEFAULT_NAME = "Unnamed.";
        
        #endregion

        #region Static Variables 

        /// <summary>
        /// A populated list of all projects in memory, pulled from the database.
        /// </summary>
        public static List<Project> Projects = new List<Project>();

        #endregion

        #region Backing Members

        private bool _playing;
        private string _name = DEFAULT_NAME;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets and sets the ID for this project.
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// Gets and sets the ID of teh owner of this project
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets and sets the name of this project.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.IsNullOrEmpty()) { throw new Exception("Project name cannot be empty."); }
                _name = value;
            }
        }

        /// <summary>
        /// Gets and sets the timeline for this project, containing all project notes.
        /// </summary>
        public List<Note> Timeline { get; set; }

        /// <summary>
        /// Gets and sets the composed timeline for this project, containing an organized
        /// list of nullable notes, where each index represents the element at that index.
        /// </summary>
        public List<Note?> ComposedTimeline { get; set; }

        /// <summary>
        /// Gets and sets the length of this project's timeline, in milliseconds
        /// </summary>
        public int TimelineLength { get; set; }

        /// <summary>
        /// Gets and sets the buffer point when the timeline is playing. If the timeline is not playing,
        /// becomes -1.
        /// </summary>
        public int BufferPoint { get; set; } = -1;

        /// <summary>
        /// Gets and sets bool to determine if the timeline is playing.
        /// </summary>
        public bool Playing
        {
            get => _playing;
            set
            {
                if (value == false) { BufferPoint = -1; }
                _playing = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - just instantiates this project's blank note list.
        /// </summary>
        public Project()
        {
            Timeline = new List<Note>();
            ComposedTimeline = new List<Note?>();
        }

        /// <summary>
        /// Parameterized constructor - instantiates this project's pre-populated note list with 
        /// a timeline length. Composes timeline since it is already populated.
        /// </summary>
        /// <param name="timeline">A pre-populated list of notes.</param>
        /// <param name="timelineLength">The length of this timeline.</param>
        public Project(List<Note> timeline, int timelineLength)
        {
            Timeline = timeline;
            TimelineLength = timelineLength;
            ComposedTimeline = new List<Note?>();
            ComposeTimeline();
        }

        /// <summary>
        /// Parameterized constructor - instantiates this project's blank note list and timeline length
        /// </summary>
        /// <param name="timelineLength">The length of this timeline.</param>
        public Project(int timelineLength)
        {
            Timeline = new List<Note>();
            TimelineLength = timelineLength;
            ComposedTimeline = new List<Note?>();
        }

        #endregion

        #region Instance Methods - Timeline

        /// <summary>
        /// Adds a note to ComposedTimeline for each millisecond in timeline length.
        /// Each of these notes gets their respective notes found in Timeline with a 
        /// matching TimelineLocation. If there is no note at that millisecond, the note is null.
        /// 
        /// AI Used: Yes
        /// AI Prompt: Provided class with summary above and prompted - "Finish ComposeTimeline using the context of the class."
        /// Changes Made: Removed unnecessary second for loop.
        /// </summary>
        public void ComposeTimeline()
        {
            try
            {
                // Initialize all milliseconds in the composed timeline as null
                ComposedTimeline = new List<Note?>(new Note[TimelineLength]);

                // Add each note to it's respective spot in the composed timeline
                foreach (Note note in Timeline)
                {
                    ComposedTimeline[note.TimelineLocation] = note;
                }
            } 

            catch (Exception ex) { throw new Exception($"Error composing timeline: {ex.Message}"); }


        }

        /// <summary>
        /// Begins timeline reading timeline buffer from the specified point.
        /// </summary>
        /// <param name="pointInMilliseconds">The point to play the timeline from.</param>
        public void PlayTimelineFromPoint(int pointInMilliseconds)
        {
            BufferPoint = pointInMilliseconds;
            Playing = true;
        }

        /// <summary>
        /// Modeled after dotnet file read classes - returns true if Playing is true, and 
        /// scans to next millisecond in composed timeline, playing a note at that point if it exists.
        /// AI Used: Prompted to give me a better alternative to Thread.Sleep() for breaking in between
        ///          milliseconds. AI provided stopwatch.
        ///          AI then reccomended Task.Run(), and making the method async as to not block the UI
        /// </summary>
        public async Task Play()
        {
            // Use Task.Run to keep UI running
            await Task.Run(() =>
            {
                // Start stop watch
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Plays the next note in the timeline if it isn't null
                ComposedTimeline[BufferPoint]?.Play();

                // Moves buffer point and checks if buffer has been fully read.
                BufferPoint++;
                if (BufferPoint >= TimelineLength)
                {
                    BufferPoint = -1;
                    Playing = false;
                }

                // Ensure a milliseconds has passed before exiting
                while (stopwatch.ElapsedMilliseconds < 1) { }

            });
        }

        /// <summary>
        /// Adds a cloned parent note to the uncomposed timeline by it's number.
        /// </summary>
        /// <param name="note">The note number.</param>
        /// <param name="timelineLocation">The location to place the note on the timeline.</param>
        public void AddNoteByNumber(int note, int timelineLocation)
        {
            // Throw error a note already exists at the specified timeline - note SoundPlayer does not support chords
            if (NoteExists(timelineLocation)) { throw new Exception("Sorry, chords are not supported! Only one note per beat."); }

            // Get timeline location as 1/4 note
            timelineLocation *= (int)Note.NoteSize.QuarterBeat;

            // Grab the note, ensure not null
            Note? parentNote = Note.GetByNoteNumber(note);
            if (parentNote == null) { return; }

            // Create a copy of the note, adding it as the parent
            Note newNote = new Note()
            {
                ParentNote = parentNote,
                CurrentNote = parentNote.CurrentNotePlayer, // Returns a cloned memory stream
                NoteNumber = parentNote.NoteNumber,
                TimelineLocation = timelineLocation
            };

            // Add non null new note to the timeline
            Timeline.Add(newNote);
        }

        /// <summary>.
        /// Removes all notes from the timeline at the specified location
        /// </summary>
        /// <param name="timelineLocation">The location to remove at.</param>
        public void RemoveNote(int timelineLocation)
        {
            // Get timeline location as 1/4 note
            timelineLocation *= (int)Note.NoteSize.QuarterBeat;

            // Cloned list as to not throw a list removal access error during loop
            List<Note> clonedTimeline = new List<Note>(Timeline.ToArray());
            foreach (Note note in clonedTimeline) 
            { 
                if (note.TimelineLocation == timelineLocation)
                {
                    Timeline.Remove(note);
                }     
            }
        }

        /// <summary>
        /// Checks if a note exists at the specified timeline location.
        /// </summary>
        /// <param name="timelineLocation">The timeline location to check.</param>
        /// <returns>True if a note exists at the location, otherwise false.</returns>
        /// AI Used: Yes
        /// Prompt: "create a NoteExists method basded on the context of the class to aid other methods."
        /// Changes Made: No changes
        public bool NoteExists(int timelineLocation)
        {
            // Convert the timeline location to 1/4 note size for consistency
            timelineLocation *= (int)Note.NoteSize.QuarterBeat;

            // Check if any note matches the given location
            return Timeline.Any(note => note.TimelineLocation == timelineLocation);
        }

        #endregion

        #region Instance Methods - Saving

        /// <summary>
        /// Attempts to serialize this project into a json, convert to a base64, and then
        /// write to database
        /// AI Used: Yes
        /// AI Prompt: I provided the Fill() method and prompted: "Create the save method to save a 
        ///            given project to the database. Just takes in a connection string and saves the 
        ///            instance it was called on"
        /// Changes Made: A lot had to be changed to get this method to work, including overhauling the
        ///               way I store projects from the ground up. 
        ///               
        ///               Storing entire project objects as base64s as suggested by AI resulted in read
        ///               and writes crashing due to the massive size of each object.
        ///               
        ///               I opted to store Projects in database as jsons instead, with a header containing the
        ///               name and length, and a body containing notes (each note gets a note name and a 
        ///               location on the timeline in milliseconds).
        /// </summary>
        /// <param name="projectName">The name to save project as.</param>
        public void Save(string projectName)
        {
            try
            {
                // Added check to ensure user is logged in
                if (User.CurrentUser == null) { throw new Exception("Please log in to save projects."); }

                // Added check to ensure project name isn't empty
                if (Name.IsNullOrEmpty()) { throw new Exception("Project name must not be empty."); }

                // Set the name before anything
                Name = projectName;

                // Serialize the current instance to a packaged JSON - Changed AI's extremely inefficient base 64 conversion
                string jsonData = JsonSerializer.Serialize(new PackagedProject(this));
                MessageBox.Show(jsonData);

                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNETION_STRING))
                {
                    connection.Open();

                    string query = @"INSERT INTO Project (ProjectID, UserID, ProjectData) 
                                     VALUES (@ProjectID, @UserID, @ProjectData)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Set the parameter values
                        command.Parameters.AddWithValue("@ProjectID", ProjectID);
                        command.Parameters.AddWithValue("@UserID", User.CurrentUser.UserID);
                        command.Parameters.AddWithValue("@ProjectData", jsonData);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception($"Error {ex.Message}");
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Deserializes each json in Project table.
        /// AI Used: Yes
        /// Prompt: I provided the class, and asked: "Build me a fill method which fill's the static Project list
        ///         by reading the ProjectData attribute as a base64 string. Projects are stored in the database
        ///         with ProjectID, UserID, and ProjectData attributes.
        /// Changes Made: Since I changed from base64 storage to json strings, I simply changed the method 
        ///               so it reads as a string and desrializes to a PackagedProject, and then a Project.
        /// </summary>
        public static void Fill()
        {
            // Clear the Projects list to avoid duplication if called multiple times
            Projects.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Resources.CONNETION_STRING))
                {
                    connection.Open();

                    string query = "SELECT ProjectID, UserID, ProjectData FROM Project";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Everything here is changed from what AI provided
                            while (reader.Read())
                            {
                                // Read the ProjectData as a json 
                                string jsonData = (string)reader["ProjectData"];

                                // Changed AI's base 64 read deserialization to instead use a PackagedProject, and then just unpackage if not null
                                PackagedProject? packagedProject = JsonSerializer.Deserialize<PackagedProject>(jsonData);

                                // Throw error if null, otherwise bring the project into memory.
                                if (packagedProject == null) { throw new Exception("Could not unpackage project."); }
                                Projects.Add(packagedProject.Unpackage((int)reader["ProjectID"], (int)reader["UserID"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Throw an exception if fill failed
                throw new Exception($"Error loading projects: {ex.Message}");
            }
        }

        /// <summary>
        /// Takes in a timeline location in milliseconds and returns the corresponding note.
        /// </summary>
        /// <param name="timelineLocation">The location to search at.</param>
        /// <returns>The note which was found, or null</returns>
        public Note? GetNoteByTimelineLocation(int timelineLocation)
        {
            foreach (Note note in Timeline)
            {
                if (note.TimelineLocation == timelineLocation)
                {
                    return note;
                }
            }
            return null;
        }


        #endregion
    }
}

#endregion
