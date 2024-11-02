/*
 * Title: Race.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-02
 * Purpose: To provide an instantiatable Race class, and a static List to store each race instance.
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
    /// Represents a Dungeons and Dragons Race.
    /// Each instantiated race will:
    /// 
    /// 1. Contain a Name, Description and Dictionary of Attributes, where each
    /// key is an enum of type Constants.Attribute, and each value is an int
    /// representing the bonus points this race contains for that attribute.
    /// 
    /// 2. Be stored in the static List Race.Races.
    /// </summary>
    internal class Race
    {

        #region Static Variables

        /// <summary>
        /// Static list containing all instantiated Races.
        /// </summary>
        public static List<Race> Races = new List<Race>();

        #endregion

        #region Instance Properties

        /// <summary>
        /// The name of this Race.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of this race.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// A dictionary contianing the bonus points corresponding to each attribute for this Race.
        /// </summary>
        public Dictionary<Constants.Attribute, int>? Attributes { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - Simply sets a default Name and Description for this race. Bonus attributes will
        /// be randomly assigned.
        /// </summary>
        public Race()
        {
            SetDefaults();
        }

        #endregion

        #region Default Setup

        /// <summary>
        /// Sets default name and description before randomizing attributes.
        /// </summary>
        private void SetDefaults()
        {
            Name = Constants.DefaultRace;
            Description = Constants.DefaultRaceDescription;
            RandomizeAttributes();
        }

        /// <summary>
        /// Randomizes bonus attributes points for each attribute.
        /// Each attribute will get a maximum of one point added in bonus for this unknown race.
        /// </summary>
        private void RandomizeAttributes()
        {
            SetAttributes(
                Tools.GetRandomInt(0,1), Tools.GetRandomInt(0, 1), 
                Tools.GetRandomInt(0, 1), Tools.GetRandomInt(0, 1), 
                Tools.GetRandomInt(0, 1), Tools.GetRandomInt(0, 1)
                );
        }

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

        #region Static Methods

       

        #endregion

    }
}

#endregion
