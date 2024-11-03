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
using static Assignment3.Constants;

#endregion

#region Namspace Definition

namespace Assignment3
{

    /// <summary>
    /// An instantiatable Dungeons and Dragons character.
    /// </summary>
    internal class Character
    {

        #region Backing Members

        private int _level;
        private string _name;
        private int _experiencePoints;
        private Race? _race;

        #endregion

        #region Staic Variables

        /// <summary>
        /// Static list of all Character instances.
        /// </summary>
        public static List<Character> Characters = new List<Character>();

        #endregion

        #region Instance Properties

        public string Name
        {
            get { return _name; }
            set
            {
                if (FindByName(value) != null && FindByName(value) != this)
                {
                    throw new Exception($"Character name is already taken.");
                }
                else if (value.Length > Constants.MaximumNameSize || value.Length < Constants.MinimumNameSize)
                {
                    throw new Exception($"Character name must be between {Constants.MinimumNameSize} and {Constants.MaximumNameSize} in length.");
                }
                else { _name = value; }
            }
        }

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
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                Level = CalculateLevel(value);
                _experiencePoints = value;
            }
        }

        /// <summary>
        /// The race of this character.
        /// </summary>
        public Race? Race
        {
            get { return _race; }
            set
            {
                if (!RaceBonusRecieved) { _race = value; }
            }
        }

        public Constants.Alignment Alignment { get; set; }

        public Constants.Gender Gender { get; set; }

        public Dictionary<Constants.Attribute, int>? Attributes { get; set; }

        public int ArmourClass { get; set; }

        /// <summary>
        /// The characters initiative. Initiative = Dexterity modifier.
        /// Dexterity modifier = (totalDexterity - 10) / 2
        /// </summary>
        public int Initiatve { get; set; }

        /// <summary>
        /// The points available to assign to attributes. 
        /// If this is a fresh character, this should be set to 27.
        /// If this is an existing character, the user who is intantiating can determine this number.
        /// </summary>
        public int AttributePoints { get; set; }

        public int Speed { get; set; }

        /// <summary>
        /// The characters health. HitPoints = classHPDice + Constitution modifier.
        /// Constitution modifier = (totalConstitution - 10) / 2
        /// </summary>
        public int HitPoints { get; private set; }

        /// <summary>
        /// If the user has ASG/has leveled up to the point where they can generate attributes,
        /// this is true. True by default.
        /// </summary>
        public bool HasAbilityScoreGeneration { get; set; }

        /// <summary>
        /// Becomes true when the character locks in their initial race and attributes. Character can not change race if this is true.
        /// </summary>
        public bool RaceBonusRecieved { get; set; }

        /// <summary>
        /// Becomes true when the character makes a change to their gender.
        /// If it is true, the previos gender bonus should be removed before the new one is added.
        /// </summary>
        public bool GenderBonusRecieved { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Paramaterized constructor - to be called when all character data is known prior to insntantiation.
        /// </summary>
        public Character(string name, Class chosenClass, Race race, Constants.Alignment alignment, Constants.Gender gender,
            List<int> attributes, int attributePoints, int armourClass, bool hasAbilityScoreGeneration)
        {
            Name = name;
            Class = chosenClass;
            Race = race;
            Alignment = alignment;
            Gender = gender;
            ArmourClass = armourClass;
            AttributePoints = attributePoints;
            HasAbilityScoreGeneration = hasAbilityScoreGeneration;
            RaceBonusRecieved = false;
            GenderBonusRecieved = false;


            SetAttributes(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5]);
            SetInitiative();
            Characters.Add(this);
        }

        /// <summary>
        /// Default constructor - to be called when all character data is not known prior to insntantiation.
        /// </summary>
        public Character()
        {
            Name = Constants.DefaultCharacterName + Constants.DefaultCharacterNameAutoNum++;
            Race = Race.FindByName(Constants.DefaultRace);
            Alignment = Constants.DefaultAlignment;
            Gender = Constants.DefaultGender;
            ArmourClass = Constants.DefaultArmourClass;
            AttributePoints = Constants.StartingAttributePoints;
            HasAbilityScoreGeneration = true;
            RaceBonusRecieved = false;
            GenderBonusRecieved = false;

            SetDefaultAttributes();
            SetInitiative();
        }

        #endregion

        #region Default Setup

        /// <summary>
        /// Sets all attributes to the default int specified in Constants.cs.
        /// </summary>
        private void SetDefaultAttributes()
        {
            int attributeScore = Constants.DefaultAttributeScore;
            SetAttributes(attributeScore, attributeScore, attributeScore, attributeScore, attributeScore, attributeScore);
        }

        /// <summary>
        /// Initiative is set to dexterity modifier.
        /// </summary>
        private void SetInitiative()
        {
            if (Attributes == null) { return; }
            Initiatve = CalculateInitiative(Attributes[Constants.Attribute.Dexterity]);
        }

        #endregion

        #region Manual Setup

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

        #region Bonus Points Addition

        /// <summary>
        /// Applies race bonus to attributes.
        /// </summary>
        public void ApplyBonusPoints()
        {
            if (Race == null || Race.Attributes == null || Attributes == null) { return; }
            
            // Race bonus
            foreach (KeyValuePair<Constants.Attribute, int> attribute in Race.Attributes)
            {
                Attributes[attribute.Key] = Math.Min(Attributes[attribute.Key] + Race.Attributes[attribute.Key], Constants.MaxAttributeScore);
            }

            RaceBonusRecieved = true;
        }
        
        /// <summary>
        /// Removes current gender bonus if it exists, switches gender, and adds new gender bonus to attributes.
        /// </summary>
        /// <param name="gender"></param>
        public void ApplyGenderBonus(Gender gender)
        {
            if (GenderBonusRecieved) { RemoveGenderBonus(); }
            AddGenderBonus(gender);
        }

        /// <summary>
        /// Removes  bonus attributes corresponding with the current gender
        /// </summary>
        private void RemoveGenderBonus()
        {
            // Ensure attributes exist before removing
            if (Attributes == null) { return; }
            if (Gender == Constants.Gender.Male)
            {
                Attributes[Constants.Attribute.Strength] = Math.Max(Attributes[Constants.Attribute.Strength] - 1, Constants.MinAttributeScore);
                Attributes[Constants.Attribute.Wisdom] = Math.Max(Attributes[Constants.Attribute.Wisdom] - 1, Constants.MinAttributeScore);
            }
            else if (Gender == Constants.Gender.Female)
            {
                Attributes[Constants.Attribute.Dexterity] = Math.Max(Attributes[Constants.Attribute.Dexterity] - 1, Constants.MinAttributeScore);
                Attributes[Constants.Attribute.Intelligence] = Math.Max(Attributes[Constants.Attribute.Intelligence] - 1, Constants.MinAttributeScore);
            }
            else
            {
                Attributes[Constants.Attribute.Constitution] = Math.Max(Attributes[Constants.Attribute.Constitution] - 1, Constants.MinAttributeScore);
                Attributes[Constants.Attribute.Charisma] = Math.Max(Attributes[Constants.Attribute.Charisma] - 1, Constants.MinAttributeScore);
            }
        }

        /// <summary>
        /// Adds bonus attributes corresponding with the passed in gender, updates gender
        /// </summary>
        /// <param name="genderToSwitchTo">The gender to pull bonus points from and switch to.</param>
        private void AddGenderBonus(Gender genderToSwitchTo)
        {
            // Ensure attributes exist before removing
            if (Attributes == null) { return; }
            if (genderToSwitchTo == Constants.Gender.Male)
            {
                Attributes[Constants.Attribute.Strength] = Math.Min(Attributes[Constants.Attribute.Strength] + 1, Constants.MaxAttributeScore);
                Attributes[Constants.Attribute.Wisdom] = Math.Min(Attributes[Constants.Attribute.Wisdom] + 1, Constants.MaxAttributeScore);
            }
            else if (genderToSwitchTo == Constants.Gender.Female)
            {
                Attributes[Constants.Attribute.Dexterity] = Math.Min(Attributes[Constants.Attribute.Dexterity] + 1, Constants.MaxAttributeScore);
                Attributes[Constants.Attribute.Intelligence] = Math.Min(Attributes[Constants.Attribute.Intelligence] + 1, Constants.MaxAttributeScore);
            }
            else
            {
                Attributes[Constants.Attribute.Constitution] = Math.Min(Attributes[Constants.Attribute.Constitution] + 1, Constants.MaxAttributeScore);
                Attributes[Constants.Attribute.Charisma] = Math.Min(Attributes[Constants.Attribute.Charisma] + 1, Constants.MaxAttributeScore);
            }

            GenderBonusRecieved = true;
            Gender = genderToSwitchTo;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets a List of 5 characters based on a page number.
        /// The page number determines which index to start pulling characters from by:
        /// multiplying pageNumber by 5, subtracting by 5, and then indexing up to the 
        /// 5 * pageNumber product 
        /// 
        /// (e.g. if pageNumber is 2, 2 * 5 = 10, so start indexing from 5 until 10 is reached.)
        /// </summary>
        /// <param name="pageNumber">The page number to get.</param>
        /// <returns>A list of up to 5 character.</returns>
        public static List<Character> GetPage(int pageNumber)
        {
            List<Character> characterPage = new List<Character>();
            int lastIndex = pageNumber * 5;
            int firstIndex = lastIndex - 5;

            // Return right away if attempting to index out of bounds
            if (firstIndex >= Characters.Count) { return characterPage; }

            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (i >= Characters.Count) { break; }
                characterPage.Add(Characters[i]);
            }

            return characterPage;
        }

        /// <summary>
        /// Searches through static Character array, returning a character with the matching name.
        /// </summary>
        /// <param name="name">The name of the character to find.</param>
        /// <returns>Null if no character was found, a Character if a matching name is found.</returns>
        public static Character? FindByName(string name)
        {
            foreach (Character character in Characters)
            {
                if (character.Name.ToLower() == name.ToLower()) { return character; }
            }
            return null;
        }

        #region Calculations

        /// <summary>
        /// Calculates a given character's level based off an xp param.
        /// </summary>
        /// <param name="xp">The amount of xp a character has.</param>
        /// <returns>The level of the character, or -1 if invalid xp amount.</returns>
        public static int CalculateLevel(int xp)
        {
            // Iterates backwards through dictionary of levels to easily check character level. If xp is greater than any level iteration, character is that level.
            for (int i = Constants.LevelsToXpRequirements.Count - 1; i >= 0; i--)
            {
                if (xp >= Constants.LevelsToXpRequirements.ElementAt(i).Value) { return Constants.LevelsToXpRequirements.ElementAt(i).Key; }
            }
            return -1;
        }

        /// <summary>
        /// Calculates a given character's hit points based off a class and constitution level.
        /// </summary>
        /// <param name="className">The name of the class to pull an HPDice from.</param>
        /// <param name="constitution">Total constitution of a given character.</param>
        /// <returns>The hit points of the character, or the hit points of the character's constiution with a default class if no matching class.</returns>
        public static int CalculateHitPoints(string className, int constitution)
        {
            return Class.FindByName(className).HPDice + (constitution - 10) / 2;
        }

        /// <summary>
        /// Calculates a given character's initiative based off a dexterity level.
        /// </summary>
        /// <param name="dexterity">The dexterity of the character.</param>
        /// <returns></returns>
        public static int CalculateInitiative(int dexterity)
        {
            return (dexterity - 10) / 2;
        }

        /// <summary>
        /// Calculates the cost of a given attribute based off it's current level/value
        /// </summary>
        /// <param name="attributeValue">The current level of the attribute</param>
        /// <returns>The cost to upgrade to next level, or -1 if attributeValue is not in correct range.</returns>
        public static int CalculateAttributeCost(int attributeValue)
        {
            foreach (KeyValuePair<int, int> cost in Constants.AttributeCosts)
            {
                if (attributeValue <= cost.Key) { return cost.Value; }
            }
            return -1;
        }

        /// <summary>
        /// Deletes a character from the static list of character's by it's name.
        /// </summary>
        /// <param name="characterToDeleteByName">The character to be removed.</param>
        public static void Delete(string characterToDeleteByName)
        {
            // Search for a matching character
            Character? characterToDelete = FindByName(characterToDeleteByName);
            if (characterToDelete == null) { return; }

            // If there's a match, remove it from the static list
            Characters.Remove(characterToDelete);
        }

        #endregion

        #endregion

    }
}

#endregion
