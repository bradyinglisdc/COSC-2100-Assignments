/*
 * Title: Note.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-11
 * Purpose: To provide a MemoryStream with data members specific a Note.
 * AI Used: AI was used to develop the Resize and play methods of this class, further documentation can be found there.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Resources;
using System.Media;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Reliant on MemoryStream class; this class provides the methods necessary to model a Note that aggregates a larger music project.
    /// At it's core, a note contains a nullable reference to it's parent note, which will be used for trimming and expanding the current
    /// state of the note. 
    /// 
    /// A note can be up to 4 seconds long (or 4 beats long since this project has been developed with a bpm of 60 in mind), and must be a
    /// minimum of 1/4 a second/beat long.
    /// 
    /// Essentially, on resize the front-end will hand down a NoteSize enum, and the corresponding .wav memory stream will be trimmed accordingly.
    /// </summary>
    internal class Note
    {
        #region Static Variables/Constants/Enums

        /// <summary>
        /// All parent notes are stored here, modeling the raw .wav files as MemorySteam objects.
        /// </summary>
        public static List<Note> Parents = new List<Note>();

        /// <summary>
        /// Each NoteSize corresponds to a number of milliseconds.
        /// </summary>
        public enum NoteSize
        {
            QuarterBeat = 250,
            HalfBeat = 500,
            FullBeat = 1000,
            TwoBeats = 2000,
            FourBeats = 4000
        }

        /// <summary>
        /// The directory where raw notes will be read from.
        /// </summary>
        private static string RawNotesDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Note\\RawNotes";


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

        /// <summary>
        /// For simplicity sake, the actual note names will not be visible here. They will instead
        /// be kept track of as an integer, where NoteNumber 0 is C0 and NoteNumber 132 is b10.
        /// </summary>
        public int NoteNumber { get; set; }

        /// <summary>
        /// This notes placement in the conceptual timeline; to be utilized by it's respective Project
        /// </summary>
        public int TimelineLocation { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - ParentNote and CurrentNote are kept as null.
        /// </summary>
        public Note()
        {
            ParentNote = null;
            CurrentNote = null;
            Size = NoteSize.FourBeats;
        }

        /// <summary>
        /// Parameterized constructor - both ParentNote and CurrentNote are set to the specified param value.
        /// </summary>
        public Note(Note parentNote)
        {
            ParentNote = parentNote;
            CurrentNote = ParentNote.CurrentNote;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Tries to read all .wav files in Note.RawNotes into Parents list. This method is async because it can take quite
        /// some time, based on the read/write speed of the hardware.
        /// </summary>
        public static void FillParents()
        {

            try
            {
                // Grab the RawNotes directory as an array of strings for each files name
                string[] rawNoteFiles = Directory.GetFiles(RawNotesDirectory);

                // Iterate through each file, instantiating a note in the order of their index for each
                foreach (string file in rawNoteFiles)
                {
                    Parents.Add(new Note()
                    {
                        NoteNumber = int.Parse(file.Split("\\")[^1].Replace(".wav", "")),
                        CurrentNote = ReadNote(file)
                    });
                }
            }

            catch (Exception ex) { throw new($"Error loading notes: {ex.Message}"); }

        }

        /// <summary>
        /// Reads the specified .wav note into memory based on a string directory
        /// </summary>
        /// <param name="noteFile">The note to read into memory</param>
        /// <returns>A MemoryStream representing the byte data for the specified note</returns>
        private static MemoryStream ReadNote(string noteFile)
        {
            try
            {
                return new MemoryStream(File.ReadAllBytes(noteFile));
            }

            catch (Exception ex) { throw new Exception($"Could not read note at {noteFile}: {ex.Message}"); }
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

            int bytesPerMillisecond = parentData.Length / (int)NoteSize.FourBeats; // Four beats = 4000 milliseconds (max file size)
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

        /// <summary>
        /// Plays audio for this note using SoundPlayer.
        /// AI Used: Yes
        /// Prompt: "Impliment a method for playing MemoryStream .wavs concisely"
        /// Changes Made: Removed additional declaration of MemoryStream - a stream already exists for each note.
        /// </summary>
        public void Play()
        {
            SoundPlayer player = new SoundPlayer(CurrentNote);
            player.Play();
        }

        #endregion

    }
}

#endregion