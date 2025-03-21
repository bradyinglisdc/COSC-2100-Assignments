﻿/*
 * Title: Race.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-02
 * Purpose: To provide a static class for interfacing with, and creating default values for other game related classes.
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
    /// Simply provides static methods for interfacing with game classes.
    /// </summary>
    internal static class Driver
    {
        #region Race Methods

        /// <summary>
        /// Clears all current races and instantiates 6 default races.
        /// </summary>
        public static void InstantiateDefaultRaces()
        {
            Race.Races.Clear();

            new Race(
               "Dwarf",
               """
               Ability Score Increase: Your Strength and Constitution score increase by 2.
               Age: Dwarves mature at the same rate as humans, but they’re considered young until they reach the age of 50. On average, they live about 350 years.
               Size: Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium.
               Speed: Your base walking speed is 25 feet. Your speed is not reduced by wearing heavy armor.
               """,
               new List<int> { 2, 0, 2, 0, 0, 0 },
               25
           );

            new Race(
                "Elf (High)",
                """
                Ability Score Increase: Your Dexterity score increases by 2, and your Intelligence score increases by 1.
                Age: High Elves can live over 700 years, often reaching adulthood at 100.
                Size: High Elves stand between 5 and 6 feet tall. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 0, 2, 0, 1, 0, 0 },
                39
            );

            new Race(
                "Elf (Wood)",
                """
                Ability Score Increase: Your Dexterity score increases by 2, and your Wisdom score increases by 1.
                Age: Wood Elves, like other elves, live long lives, reaching adulthood at 100 and living to 750.
                Size: Wood Elves are slightly shorter and slimmer than humans. Your size is Medium.
                Speed: Your base walking speed is 35 feet.
                """,
                new List<int> { 0, 2, 0, 0, 1, 0 },
                35
            );

            new Race(
                "Halfling",
                """
                Ability Score Increase: Your Dexterity score increases by 2, and your Charisma score increases by 1.
                Age: Halflings reach adulthood at 20 and can live up to 150 years.
                Size: Halflings average about 3 feet tall and weigh about 40 pounds. Your size is Small.
                Speed: Your base walking speed is 25 feet.
                """,
                new List<int> { 0, 2, 0, 0, 0, 1 },
                25
            );

            new Race(
                "Human",
                """
                Ability Score Increase: All your ability scores increase by 1.
                Age: Humans reach adulthood in their late teens and live less than a century.
                Size: Humans vary widely in height and build. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 1, 1, 1, 1, 1, 1 },
                30
            );

            new Race(
                "Dragonborn",
                """
                Ability Score Increase: Your Strength score increases by 2, and your Charisma score increases by 1.
                Age: Dragonborn reach adulthood by 15 and live to around 80 years.
                Size: Dragonborn stand well over 6 feet tall and average 250 pounds. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 2, 0, 2, 0, 0, 1 },
                30
            );

            new Race(
                "Gnome",
                """
                Ability Score Increase: Your Intelligence score increases by 2, and your Dexterity score increases by 1.
                Age: Gnomes mature at the same rate as humans but can live 350 to 500 years.
                Size: Gnomes stand around 3 to 4 feet tall. Your size is Small.
                Speed: Your base walking speed is 25 feet.
                """,
                new List<int> { 0, 1, 0, 2, 0, 0 },
                25
            );

            new Race(
                "Half-Elf",
                """
                Ability Score Increase: Your Charisma score increases by 2, your dexterity increases by 1, and your intelligence increases by 1.
                Age: Half-Elves mature at the same rate as humans and live around 180 years.
                Size: Half-Elves are about the same size as humans. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 0, 1, 0, 1, 0, 2 },
                30
            );

            new Race(
                "Half-Orc",
                """
                Ability Score Increase: Your Strength score increases by 2, and your Constitution score increases by 1.
                Age: Half-Orcs mature faster than humans and age quickly, living around 75 years.
                Size: Half-Orcs are between 5 and 6 feet tall, with a muscular build. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 2, 0, 1, 0, 0, 0 },
                30
            );

            new Race(
                "Tiefling",
                """
                Ability Score Increase: Your Charisma score increases by 2, and your Intelligence score increases by 1.
                Age: Tieflings mature at the same rate as humans but often live a bit longer, reaching 100 to 120 years.
                Size: Tieflings are about the same size and build as humans. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 0, 0, 0, 1, 0, 2 },
                30
            );

            new Race(
                "Githyanki",
                """
                Ability Score Increase: Your Strength score increases by 1, and your Dexterity score increases by 2.
                Age: Githyanki are generally more mature than humans at 20 and live around 100 years.
                Size: Githyanki are similar in height and build to humans. Your size is Medium.
                Speed: Your base walking speed is 30 feet.
                """,
                new List<int> { 1, 2, 0, 0, 0, 0 },
                30
            );
        }

        #endregion

        #region Character Methods

        /// <summary>
        /// This method exists only to instantiate example character classes.
        /// </summary>
        public static void InstantiateExampleCharacters()
        {
            new Character("Thalrin Ironbrow", Class.Classes[0], Race.Races[0], Constants.Alignment.LawfulGood, Constants.Gender.Male, 
                new List<int>() { 16, 16, 12, 12, 12, 12}, 2, 12, true);
            
            new Character("Elara Moonshadow", Class.Classes[1], Race.Races[1], Constants.Alignment.NeutralGood, Constants.Gender.Male,
                new List<int>() { 14, 14, 13, 13, 13, 13 }, 2, 12, true);

            new Character("Kairos Emberflame", Class.Classes[2], Race.Races[2], Constants.Alignment.Neutral, Constants.Gender.Male,
                new List<int>() { 14, 14, 13, 13, 13, 13 }, 2, 12, true);

        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Instantiates the 6 default classes.
        /// </summary>
        public static void InstantiateDefaultClasses()
        {
            new Class("Barbarian", "A fierce warrior of primitive background who can enter a battle rage", 12, "BarbarianIcon.PNG");
            new Class("Bard", "An inspiring magician whose power echoes the music of creation", 8, "BardIcon.PNG");
            new Class("Cleric", "A priestly champion with divine magic granted by their deity", 8, "ClericIcon.PNG");
            new Class("Druid", "A priest of the Old Faith wielding the powers of nature", 8, "DruidIcon.PNG");
            new Class("Fighter", "A master of martial combat, skilled with a variety of weapons and armor", 10, "FighterIcon.PNG");
            new Class("Monk", "A master of martial arts, harnessing the power of the body and mind", 8, "MonkIcon.PNG");
            new Class("Paladin", "A holy warrior bound by a sacred oath to protect the innocent", 10, "PaladinIcon.PNG");
            new Class("Ranger", "A warrior who uses martial prowess and nature magic to hunt foes", 10, "RangerIcon.PNG");
            new Class("Sorcerer", "A spellcaster who draws on inherent magic from a gift or bloodline", 6, "SorcererIcon.PNG");
            new Class("Warlock", "A wielder of magic bestowed by a pact with an otherworldly being", 8, "WarlockIcon.PNG");
            new Class("Wizard", "A scholarly magic-user capable of manipulating the structures of reality", 6, "WizardIcon.PNG");
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Instantiates default Classes, Races, and example Characters
        /// </summary>
        public static void InstantiateDefaultGameObjects()
        {
            InstantiateDefaultRaces();
            InstantiateDefaultClasses();
            InstantiateExampleCharacters();
        }

        #endregion

    }
}

#endregion