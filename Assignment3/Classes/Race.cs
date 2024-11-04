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
using System.Xml.Linq;

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

        /// <summary>
        /// The speed which this race gets by default.
        /// </summary>
        public int Speed { get; set; }

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

        /// <summary>
        /// Parameterized constructor - Sets a  Name, Description, and bonus points attributes for this race
        /// based on parameters.
        /// </summary>
        /// <param name="name">The name of this race.</param>
        /// <param name="description">The description of this race.</param>
        /// <param name="attributes">The attributes as integers of this race.</param>
        public Race(string name, string description, List<int> attributes, int speed)
        {
            SetGenericProperties(name, description, speed);
            SetAttributes(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5]);
        }

        #endregion

        #region Default Setup

        /// <summary>
        /// Sets default name and description before randomizing attributes.
        /// </summary>
        private void SetDefaults()
        {
            SetGenericProperties(Constants.DefaultRace, Constants.DefaultRaceDescription, Constants.DefaultRaceSpeed);
            RandomizeAttributes();
        }

        /// <summary>
        /// Sets the name and description of this race before adding it to the static list of races.
        /// </summary>
        /// <param name="name">Race name</param>
        /// <param name="description">Race description</param>
        /// <param name="speed">Race speed</param>
        private void SetGenericProperties(string name, string description, int speed)
        {
            Name = name;
            Description = description;
            Speed = speed;
            Races.Add(this);
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

        #region General Instance Methods

        /// <summary>
        /// Formats the bonus so it is human readable (e.g. Strength + 1, Constitution + 1)
        /// </summary>
        /// <returns></returns>
        public string GetFormattedBonus()
        {
            
            string formattedBonus = "Race Bonus: ";
            if (Attributes == null) { return formattedBonus; }

            // If it's a human, apply special formatting and return
            if (Name == "Human")
            {
                formattedBonus += "+1 To All";
                return formattedBonus;
            }

            foreach (KeyValuePair<Constants.Attribute, int> attribute in Attributes)
            {
                if (attribute.Value > 0)
                {
                    formattedBonus += $"""
                        +{attribute.Value.ToString()} {attribute.Key.ToString()} 
                        """;
                }
            }

            return formattedBonus;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Searches through static list for matching race, returning it if match.
        /// </summary>
        /// <param name="raceToFind">The race to finc by name.</param>
        /// <returns>First race in array if no match, the matching race if there is match.</returns>
        public static Race FindByName(string raceToFind)
        {
            foreach (Race race in Races)
            {
                if (race.Name == raceToFind) { return race; }
            }
            return Races[0];
        }

        /// <summary>
        /// Returns a list of the names of all instantiated races.
        /// </summary>
        /// <returns>List of the name of all instantiated races.</returns>
        public static List<string> GetRaceNames()
        {
            List<string> raceNames = new List<string>();
            foreach (Race race in Races)
            {
                if (race.Name != null) { raceNames.Add(race.Name); }
            }
            return raceNames;
        }

        /// <summary>
        /// Returns a random race name within static list of races.
        /// </summary>
        /// <returns>The name of the randomly picked race, or an empty string if a null race name was found</returns>
        public static string GetRandom()
        {
            // Randomly pick a number within size of race array
            int raceIndex = Tools.GetRandomInt(0, Races.Count);

            // Return the race name if it isn't null
            Race raceChoice = Races[raceIndex];
            if (raceChoice.Name == null) { return string.Empty; }
            return raceChoice.Name;
        }


        #endregion

    }
}

#endregion
