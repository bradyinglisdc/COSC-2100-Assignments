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
    /// This static class contains the constants and enums related to the character creator.
    /// Each region corresponds to a class or related enum/constant collection.
    /// </summary>
    internal static class Constants
    {
        #region File Locating

        public static string ProjectDirectory = (Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent).FullName;
        public static string RersourcesDirectory = ProjectDirectory + "\\Resources";
        public static string ClassIconsDirectory = RersourcesDirectory + "\\ClassIcons";

        #endregion


        #region Alignments and Attribute names

        /// <summary>
        /// Name of an attribute associated with a character/race.
        /// </summary>
        public enum Attribute
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }

        /// <summary>
        /// Name of an alignment to be assigned to a character.
        /// </summary>
        public enum Alignment
        {
            LawfulGood,
            NeutralGood,
            ChaoticGood,
            LawfulNeutral,
            Neutral,
            ChaoticNeutral,
            LawfulEvil,
            NeutralEvil,
            ChaoticEvil
        }

        /// <summary>
        /// A standard applicable alignment.
        /// </summary>
        public const Alignment DefaultAlignment = Alignment.LawfulGood;

        /// <summary>
        /// Character alignment names and descriptions.
        /// </summary>
        public static Dictionary<Alignment, string> AlignmentDescriptions = new Dictionary<Alignment, string>
        {
            {Alignment.LawfulGood, """
                Lawful good (LG) creatures can be counted on to do the right thing as expected by society. Gold 
                dragons, paladins, and most dwarves are lawful good.
                """},
            
            {Alignment.NeutralGood, """
                Neutral good (NG) folk do the best they can to help others according to their needs. Many 
                celestials, some cloud giants, and most gnomes are neutral good.
                """},
            
            {Alignment.ChaoticGood, """
                Chaotic good (CG) creatures act as their conscience directs, with little regard for what others 
                expect. Copper dragons, many elves, and unicorns are chaotic good.
                """},
            
            {Alignment.LawfulNeutral, """
                Lawful neutral (LN) individuals act in accordance with law, tradition, or personal codes. Many 
                monks and some wizards are lawful neutral.
                """},
           
            {Alignment.Neutral, """
                Neutral (N) is the alignment of those who prefer to steer clear of moral questions and don’t take sides,
                doing what seems best at the time. Lizardfolk, most druids, and many humans are neutral.
                """},
          
            {Alignment.ChaoticNeutral, """
                Chaotic neutral (CN) creatures follow their whims, holding their personal freedom above all else. 
                Many barbarians and rogues, and some bards, are chaotic neutral.
                """},
            
            {Alignment.LawfulEvil, """
                Lawful evil (LE) creatures methodically take what they want, within the limits of a code of tradition, 
                loyalty, or order. Devils, blue dragons, and hobgoblins are lawful evil.
                """},
           
            {Alignment.NeutralEvil, """
                Neutral evil (NE) is the alignment of those who do whatever they can get away with, without 
                compassion or qualms. Many drow, some cloud giants, and goblins are neutral evil.
                """},
            
            {Alignment.ChaoticEvil, """
                Chaotic evil (CE) creatures act with arbitrary violence, spurred by their greed, hatred, or bloodlust. 
                Demons, red dragons, and orcs are chaotic evil.
                """},
        };

        /// <summary>
        /// The maximum level an attribute can obtain.
        /// </summary>
        public const int MaxAttributeScore = 20;

        /// <summary>
        /// The minimum level an attribute can obtain.
        /// </summary>
        public const int MinAttributeScore = 8;

        #endregion

        #region Class

        /// <summary>
        /// Default class is unknown - nothing is known about the characters class origin.
        /// </summary>
        public const string DefaultClass = "Unknown";

        /// <summary>
        /// Default class is described as being unknown.
        /// </summary>
        public const string DefaultClassDescription = """
            Nothing is currently known about this characters class.
            """;

        /// <summary>
        /// Default class HP dice is a moderate 8.
        /// </summary>
        public const int DefaultHPDice = 8;

        #endregion

        #region Race

        /// <summary>
        /// Default race is unknown - nothing is known about the characters racial origin.
        /// </summary>
        public const string DefaultRace = "Unknown";

        /// <summary>
        /// Default race is described as having random attributes.
        /// </summary>
        public const string DefaultRaceDescription = """
            Nothing is known about the origins of this character's race - it remains a complete mystery.
            They may be inherently strong or weak, smart or dull; their attributes seem to be completely random.
            """;

        /// <summary>
        /// The default speed a race will get.
        /// </summary>
        public const int DefaultRaceSpeed = 10;

        #endregion

        #region Character

        /// <summary>
        /// Character must be at least this level.
        /// </summary>
        public const int MinimumCharacterLevel = 1;

        /// <summary>
        /// Character must be at most this level.
        /// </summary>
        public const int MaximumCharacterLevel = 20;

        /// <summary>
        /// Gender associated with a character.
        /// </summary>
        public enum Gender
        {
            Male,
            Female,
            Other
        }

        /// <summary>
        /// Un-named characters get this name.
        /// </summary>
        public const string DefaultCharacterName = "Unknown ";
        public static int DefaultCharacterNameAutoNum = 1;

        /// <summary>
        /// The default gender is assigned as male.
        /// </summary>
        public const Gender DefaultGender = Gender.Male;

        /// <summary>
        /// Default armour class is 4.
        /// </summary>
        public const int DefaultArmourClass = 4;

        /// <summary>
        /// The default score to be applied to a generic character's attrbutes to start.
        /// </summary>
        public const int DefaultAttributeScore = 8;

        /// <summary>
        /// The number of points the player has to assign to attributes to start.
        /// </summary>
        public const int StartingAttributePoints = 27;

        /// <summary>
        /// The maximum characters a character can be.
        /// </summary>
        public const int MaximumNameSize = 20;

        /// <summary>
        /// The minimum characters a character can be.
        /// </summary>
        public const int MinimumNameSize = 5;

        #endregion

        #region Levels/Costs

        /// <summary>
        /// Each key represents a level, and each value the experience points required to reach it
        /// </summary>
        public static Dictionary<int, int> LevelsToXpRequirements = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 300 },
            { 3, 900 },
            { 4, 2700 },
            { 5, 6500 },
            { 6, 14000 },
            { 7, 23000 },
            { 8, 34000 },
            { 9, 48000 },
            { 10, 64000 },
            { 11, 85000 },
            { 12, 100000 },
            { 13, 120000 },
            { 14, 140000 },
            { 15, 165000 },
            { 16, 195000 },
            { 17, 225000 },
            { 18, 265000 },
            { 19, 305000 },
            { 20, 355000 }
        };

        /// <summary>
        /// Each key represents an attribute value, and each value the cost within that range.
        /// </summary>
        public static Dictionary<int, int> AttributeCosts = new Dictionary<int, int>()
        {
            { 13, 1 },
            { 18, 2 },
            { 20, 3 }
        };

        /// <summary>
        /// Gender bonus attributes as a dictionary. Key represents a gender, value represents is dictionary of attributes.
        /// </summary>
        public static Dictionary<Gender, Dictionary<Attribute, int>> GenderBonuses = new Dictionary<Gender, Dictionary<Attribute, int>>()
        {
            {
                Gender.Male, new Dictionary<Attribute, int>()
                {
                    { Attribute.Strength, 1 },
                    { Attribute.Wisdom, 1 }
                }
            },

            {
                Gender.Female, new Dictionary<Attribute, int>()
                {
                    { Attribute.Dexterity, 1 },
                    { Attribute.Intelligence, 1 }
                }
            },

            {
                Gender.Other, new Dictionary<Attribute, int>()
                {
                    { Attribute.Constitution, 1 },
                    { Attribute.Charisma, 1 }
                }
            }
        };

        /// <summary>
        /// The maximum experience points a character can obtain.
        /// </summary>
        public const int MaximumXP = 355000;

        #endregion


    }
}

#endregion
