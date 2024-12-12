/*
 * Title: Project.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-11
 * Purpose: To provide an organized collection of notes, forming a single project
 * AI Used: AI was used to develop the ComposeTimeline() and Play() method, more documentation found there (lines 98 and 137)
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

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
        public bool Playing { get; set; }

        #endregion

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

        #region Instance Methods

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
        /// AI Used: No
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
        /// </summary>
        /// <returns>True if the timeline is still playing.</returns>
        public void Play()
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
        }

        public 

        #endregion
    }
}

#endregion
