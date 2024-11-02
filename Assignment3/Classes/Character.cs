/*
 * Title: Character.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-02
 * Purpose: To provide an instantiatable class representing a d&d character.
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region Namspace Definition

namespace Assignment3.Classes
{

    /// <summary>
    /// An instantiatable Dungeons and Dragons character.
    /// </summary>
    internal class Character
    {

        #region Backing Members

        private int _level;

        #endregion

        #region Staic Variables

        /// <summary>
        /// Static list of all Character instances.
        /// </summary>
        public static List<Character> Characters = new List<Character>();

        #endregion

        #region Instance Properties

        /// <summary>
        /// This character's class.
        /// </summary>
        public Class? Class { get; set; }

        /// <summary>
        /// Returns this character's level, sets this character's level
        /// if it is within the acceptable range.
        /// </summary>
        public int Level
        {
            get { return _level; }
            private set
            {
                if (value <= Constants.MaximumCharacterLevel && value >= Constants.MinimumCharacterLevel) { _level = value; }
            }
        }

        /// <summary>
        /// The total experience points this character has.
        /// </summary>
        public int ExperiencePoints { get; set; } 

        /// <summary>
        /// The race of this character.
        /// </summary>
        public Race? Race { get; set; }

        public Constants.Alignment Alignment { get; set; }

        public Constants.Gender Gender { get; set; }

        public Dictionary<Constants.Attribute, int>? Attributes { get; set; }

        public string? ArmourClass { get; set; }

        public int Initiatve { get; set; }

        public int Speed { get; set; }

        /// <summary>
        /// The characters health. This value is determined by:
        /// startingHP + classHP + (constitutionPoints * level - 1)
        /// </summary>
        public int HitPoints { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Def
        /// </summary>
        public Character()
        {

        }

        /// <summary>
        /// Param
        /// </summary>
        public Character(Race race, Constants.Alignment alignment, Constants.Gender gender,  
            List<int> attributes, string armourClass, int initiative)
        {
            Race = race;
            Alignment = alignment;
            Gender = gender;
            SetAttributes(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5]);
            ArmourClass = armourClass;
            Initiatve = initiative;
        }

        #endregion

        #region Default Setup

        /// <summary>
        /// Sets the bonus attributes of this race based on the provided integers.
        /// </summary>
        /// <param name="strength">The bonus strength of this race.</param>
        /// <param name="dexterity">The bonus dexterity of this race.</param>
        /// <param name="constitution">The bonus constitution of this race.</param>
        /// <param name="intelligence">The bonus intelligence of this race.</param>
        /// <param name="wisdom">The bonus wisdom of this race.</param>
        /// <param name="charisma">The bonus charisma of this race.</param>
        private void SetAttributes(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            // Instantiate the attributes dict and add all bonus points
            Attributes = new Dictionary<Constants.Attribute, int>();
            Attributes.Add(Constants.Attribute.Strength, strength);
            Attributes.Add(Constants.Attribute.Dexterity, dexterity);
            Attributes.Add(Constants.Attribute.Constitution, constitution);
            Attributes.Add(Constants.Attribute.Intelligence, intelligence);
            Attributes.Add(Constants.Attribute.Wisdom, wisdom);
            Attributes.Add(Constants.Attribute.Charisma, charisma);
        }

        #endregion

    }
}

#endregion
