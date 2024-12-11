/*
 * Title: Note.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-11
 * Purpose: To provide a MemoryStream child with data members specific a Note.
 * AI Used: AI was used to develop the Resize method of this class, further documentation can be found there.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// A child of the MemoryStream class; this class provides the methods necessary to model a Note that aggregates a larger music project.
    /// At it's core, a note contains a nullable reference to it's parent note, which will be used for trimming and expanding the current
    /// state of the note. 
    /// 
    /// A note can be up to 4 seconds long (or 4 beats long since this project has been developed with a bpm of 60 in mind), and must be a
    /// minimum of 1/4 a second/beat long.
    /// 
    /// Essentially, on resize the front-end will hand down a BeatSize enum, and the corresponding .wav memory stream will be trimmed accordingly.
    /// </summary>
    internal class Note
    {
        #region Static Variables/Constants/Enums

        /// <summary>
        /// Each NoteSize corresponds to a number of milliseconds
        /// </summary>
        public enum NoteSize
        {
            QuarterBeat = 250,
            HalfBeat = 500,
            FullBeat = 1000,
            TwoBeats = 2000,
            FourBeats = 4000
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The note of origin - trimmed and expanded notes utilize this property as a base.
        /// </summary>
        public Note? ParentNote { get; set; }

        /// <summary>
        /// A memory stream of a .wav file representing this note.
        /// </summary>
        public MemoryStream? CurrentNote { get; set; }

        /// <summary>
        /// The size of this note (1/4, 1/2, 1, 2, or 4).
        /// </summary>
        public NoteSize Size { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - ParentNote and CurrentNote are kept as null.
        /// </summary>
        public Note()
        {
            ParentNote = null;
            CurrentNote = null;
        }

        /// <summary>
        /// Parameterized constructor - both ParentNote and CurrentNot are set to the specified param value.
        /// </summary>
        public Note(Note parentNote)
        {
            ParentNote = parentNote;
            CurrentNote = ParentNote.CurrentNote;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Resizes the note based on the specified NoteSize.
        /// 
        /// AI Used: Yes
        /// AI Prompt: "Using the context of this class, create a Resize method which takes in a NoteSize"
        /// Changes Made: Changed lengthInMilliseconds to be set based on integer value of NoteSize enum
        ///               instead of using a switch for comparison,
        /// </summary>
        /// <param name="newSize">The new size to resize the note to.</param>
        public void Resize(NoteSize newSize)
        {
            if (ParentNote == null || ParentNote.CurrentNote == null)
            {
                throw new InvalidOperationException("ParentNote or its CurrentNote cannot be null when resizing.");
            }

            // Calculate the length in milliseconds for the new size
            int lengthInMilliseconds = (int)newSize;

            // Set the new size
            Size = newSize;

            // Adjust the CurrentNote memory stream based on the new size
            byte[] parentData = ParentNote.CurrentNote.ToArray();

            int bytesPerMillisecond = parentData.Length / (int)NoteSize.FourBeats; // Four beats = 4000 milliseconds
            int newLengthInBytes = lengthInMilliseconds * bytesPerMillisecond;

            // Trim or expand the memory stream
            byte[] resizedData;
            if (newLengthInBytes <= parentData.Length)
            {
                resizedData = new byte[newLengthInBytes];
                Array.Copy(parentData, resizedData, newLengthInBytes);
            }
            else
            {
                resizedData = new byte[newLengthInBytes];
                Array.Copy(parentData, resizedData, parentData.Length);

                // Pad with zeros for expansion
                for (int i = parentData.Length; i < newLengthInBytes; i++)
                {
                    resizedData[i] = 0;
                }
            }

            CurrentNote = new MemoryStream(resizedData);
        }

        #endregion

    }
}

#endregion