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

        #endregion


    }
}

#endregion
