/*
 * Title: frmCharacterEditor.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-03
 * Purpose: To provide a interface for d&d character editing and creation.
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment3.Constants;

#endregion

#region Namespace Definition

namespace Assignment3
{
    /// <summary>
    /// This class serves as the interface between the user and the character which they want to edit/create.
    /// </summary>
    internal partial class frmCharacterEditor : Form
    {
        #region Styling related constants

        private const string DefaultCharacterSummary = """
            _character_ is a _gender_ of the _class_ class. _character_ is level _level_, with a total Experience Point count  of _xp_. Their race is _race_, and their alignment is _alignment_. They have _hp_ HP, an Armour Class of  _ac_, an Initiative of _initiative_, and a speed of _speed_.
            """;

        #endregion

        #region Instance Properties

        /// <summary>
        /// The character whom the user is editing/creating.
        /// </summary>
        private Character BoundCharacter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - to be called when the user is creating a new character.
        /// </summary>
        public frmCharacterEditor()
        {
            InitializeComponent();
            BoundCharacter = new Character();
        }

        /// <summary>
        /// Paramaterized constructor - to be called when the user is editing a character.
        /// </summary>
        /// <param name="character">The character to edit</param>
        public frmCharacterEditor(Character character)
        {
            InitializeComponent();
            BoundCharacter = character;
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// To be called when the form first loads - instantiates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCharacterEditor_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        /// <summary>
        /// To be called whenever a detail control value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailControl_Change(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        /// <summary>
        /// To be called whenever an attribute is added or subtracted from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributeControl_Change(object sender, EventArgs e)
        {
            ChangeAttribute(((Control)sender).Name);
        }

        /// <summary>
        /// Updates Character's properties and saves it to static list, if it is not already in said list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            SaveCharacter();
        }

        #endregion

        #region Form Setup

        /// <summary>
        /// Sets control properties to reflect the current bound character
        /// </summary>
        private void InitializeForm()
        {
            FillControlData();
            FillCharacterData();
            FillSummary();
        }

        /// <summary>
        /// Fills each combo box and other respective controls with their default values.
        /// </summary>
        private void FillControlData()
        {
            cbxGender.DataSource = Enum.GetValues(typeof(Gender));
            cbxAlignment.DataSource = Enum.GetValues(typeof(Alignment));

            cbxClass.DataSource = Class.GetClassNames();
            cbxRace.DataSource = Race.GetRaceNames();

            FillAttributeLabels();
        }

        /// <summary>
        /// Fills character data based on the current bound character
        /// </summary>
        private void FillCharacterData()
        {
            tbxName.Text = BoundCharacter.Name;
            cbxGender.Text = BoundCharacter.Gender.ToString();
            nudArmourClass.Value = BoundCharacter.ArmourClass;
            nudXP.Value = BoundCharacter.ExperiencePoints;

            if (BoundCharacter.Class == null || BoundCharacter.Race == null) { return; }
            cbxClass.Text = BoundCharacter.Class.Name;
            cbxRace.Text = BoundCharacter.Race.Name;
            cbxAlignment.Text = BoundCharacter.Alignment.ToString();
        }

        /// <summary>
        /// Fills the character summary based on the bound character's info
        /// </summary>
        private void FillSummary()
        {
            if (BoundCharacter.Class == null || BoundCharacter.Race == null) { return; }

            lblCharacterSummary.Text = DefaultCharacterSummary.Replace(
                "_character_", BoundCharacter.Name).Replace(
                "_gender_", BoundCharacter.Gender.ToString()).Replace(
                "_class_", BoundCharacter.Class.Name).Replace(
                "_level_", BoundCharacter.Level.ToString()).Replace(
                "_xp_", BoundCharacter.ExperiencePoints.ToString()).Replace(
                "_race_", BoundCharacter.Race.Name).Replace(
                "_alignment_", BoundCharacter.Alignment.ToString()).Replace(
                "_hp_", BoundCharacter.HitPoints.ToString()).Replace(
                "_ac_", BoundCharacter.ArmourClass.ToString()).Replace(
                "_initiative_", BoundCharacter.Initiatve.ToString()).Replace(
                "_speed_", BoundCharacter.Speed.ToString());
            UpdateSummary();
        }

        /// <summary>
        /// Updates the character sumarry based on control values
        /// </summary>
        private void UpdateSummary()
        {
            int characterLevel = Character.CalculateLevel(((int)nudXP.Value));
            int characterHP = Character.CalculateHitPoints(cbxClass.Text, int.Parse((lblConstitutionDigitTwo.Text + lblConstitutionDigitOne.Text)));
            int characterInitiative = Character.CalculateInitiative(int.Parse(lblDexterityDigitTwo.Text + lblDexterityDigitOne.Text));

            lblCharacterSummary.Text = DefaultCharacterSummary.Replace(
                "_character_", tbxName.Text).Replace(
                "_gender_", cbxGender.Text).Replace(
                "_class_", cbxClass.Text).Replace(
                "_level_", characterLevel.ToString()).Replace(
                "_xp_", (nudXP.Value + BoundCharacter.ExperiencePoints).ToString()).Replace(
                "_race_", cbxRace.Text).Replace(
                "_alignment_", cbxAlignment.Text).Replace(
                "_hp_", characterHP.ToString()).Replace(
                "_ac_", nudArmourClass.Value.ToString()).Replace(
                "_initiative_", characterInitiative.ToString()).Replace(
                "_speed_", BoundCharacter.Speed.ToString());
            lblRemainingPoints.Text = $"Points Remaining: {BoundCharacter.AttributePoints}";
        }

        /// <summary>
        /// Fills attribute labels with character data
        /// </summary>
        private void FillAttributeLabels()
        {
            // Split character attributes
            if (BoundCharacter.Attributes == null) { return; }
            char[] strengthArray = (BoundCharacter.Attributes[Constants.Attribute.Strength]).ToString().ToCharArray();
            char[] dexterityArray = (BoundCharacter.Attributes[Constants.Attribute.Dexterity]).ToString().ToCharArray();
            char[] constitutionArray = (BoundCharacter.Attributes[Constants.Attribute.Constitution]).ToString().ToCharArray();
            char[] intelligenceArray = (BoundCharacter.Attributes[Constants.Attribute.Intelligence]).ToString().ToCharArray();
            char[] wisdomArray = (BoundCharacter.Attributes[Constants.Attribute.Wisdom]).ToString().ToCharArray();
            char[] charismaArray = (BoundCharacter.Attributes[Constants.Attribute.Charisma]).ToString().ToCharArray();

            // Update labels
            lblStrengthDigitTwo.Text = strengthArray.Length < 2 ? "0" : strengthArray[0].ToString();
            lblStrengthDigitOne.Text = strengthArray.Length < 2 ? strengthArray[0].ToString() : strengthArray[1].ToString();

            lblDexterityDigitTwo.Text = dexterityArray.Length < 2 ? "0" : dexterityArray[0].ToString();
            lblDexterityDigitOne.Text = dexterityArray.Length < 2 ? dexterityArray[0].ToString() : dexterityArray[1].ToString();

            lblConstitutionDigitTwo.Text = constitutionArray.Length < 2 ? "0" : constitutionArray[0].ToString();
            lblConstitutionDigitOne.Text = constitutionArray.Length < 2 ? constitutionArray[0].ToString() : constitutionArray[1].ToString();

            lblIntelligenceDigitTwo.Text = intelligenceArray.Length < 2 ? "0" : intelligenceArray[0].ToString();
            lblIntelligenceDigitOne.Text = intelligenceArray.Length < 2 ? intelligenceArray[0].ToString() : intelligenceArray[1].ToString();

            lblWisdomDigitTwo.Text = wisdomArray.Length < 2 ? "0" : wisdomArray[0].ToString();
            lblWisdomDigitOne.Text = wisdomArray.Length < 2 ? wisdomArray[0].ToString() : wisdomArray[1].ToString();

            lblCharismaDigitTwo.Text = charismaArray.Length < 2 ? "0" : charismaArray[0].ToString();
            lblCharismaDigitOne.Text = charismaArray.Length < 2 ? charismaArray[0].ToString() : charismaArray[1].ToString();
        }

        #endregion

        #region Attribute Modification

        /// <summary>
        /// Increases or decreases an attribute by 1 based on the provided string.
        /// </summary>
        /// <param name="attributeModificationInfo">The name of the pressed button (e.g. attributeModificationInfo = btnIncreaseStrength)</param>
        private void ChangeAttribute(string attributeModificationInfo)
        {

            if (attributeModificationInfo == btnDecreaseStrength.Name) { ChangeAttributeLabel(false, lblStrengthDigitTwo, lblStrengthDigitOne); }
            else if (attributeModificationInfo == btnIncreaseStrength.Name) { ChangeAttributeLabel(true, lblStrengthDigitTwo, lblStrengthDigitOne); }

            else if (attributeModificationInfo == btnDecreaseDexterity.Name) { ChangeAttributeLabel(false, lblDexterityDigitTwo, lblDexterityDigitOne); }
            else if (attributeModificationInfo == btnIncreaseDexterity.Name) { ChangeAttributeLabel(true, lblDexterityDigitTwo, lblDexterityDigitOne); }

            else if (attributeModificationInfo == btnDecreaseConstitution.Name) { ChangeAttributeLabel(false, lblConstitutionDigitTwo, lblConstitutionDigitOne); }
            else if (attributeModificationInfo == btnIncreaseConstitution.Name) { ChangeAttributeLabel(true, lblConstitutionDigitTwo, lblConstitutionDigitOne); }

            else if (attributeModificationInfo == btnDecreaseIntelligence.Name) { ChangeAttributeLabel(false, lblIntelligenceDigitTwo, lblIntelligenceDigitOne); }
            else if (attributeModificationInfo == btnIncreaseIntelligence.Name) { ChangeAttributeLabel(true, lblIntelligenceDigitTwo, lblIntelligenceDigitOne); }

            else if (attributeModificationInfo == btnDecreaseWisdom.Name) { ChangeAttributeLabel(false, lblWisdomDigitTwo, lblWisdomDigitOne); }
            else if (attributeModificationInfo == btnIncreaseWisdom.Name) { ChangeAttributeLabel(true, lblWisdomDigitTwo, lblWisdomDigitOne); }

            else if (attributeModificationInfo == btnDecreaseCharisma.Name) { ChangeAttributeLabel(false, lblCharismaDigitTwo, lblCharismaDigitOne); }
            else if (attributeModificationInfo == btnIncreaseCharisma.Name) { ChangeAttributeLabel(true, lblCharismaDigitTwo, lblCharismaDigitOne); }

            UpdateSummary();
        }

        private void ChangeAttributeLabel(bool increaseAttributeLabel, Label digitTwo, Label digitOne)
        {
            int leftDigit = int.Parse(digitTwo.Text);
            int rightDigit = int.Parse(digitOne.Text);
            int attributeCost = Character.CalculateAttributeCost(int.Parse(digitTwo.Text + digitOne.Text));

            if (increaseAttributeLabel) { IncreaseAttributeLabel(leftDigit, rightDigit, digitTwo, digitOne); }
            else { DecreaseAttributeLabel(attributeCost, leftDigit, rightDigit, digitTwo, digitOne); }
        }

        /// <summary>
        /// Decreases the specified labels to reflect the user's choice
        /// </summary>
        /// <param name="attributeCost">The cost of the current attribute.</param>
        /// <param name="leftDigit">The left digit as an integer.</param>
        /// <param name="rightDigit">The right digit as an integer.</param>
        /// <param name="digitTwo">The left digit as a label.</param>
        /// <param name="digitOne">The right digit as a label.</param>
        private void DecreaseAttributeLabel(int attributeCost, int leftDigit, int rightDigit, Label digitTwo, Label digitOne)
        {
            // Simple checks to update labels accurately
            if (leftDigit == 0 && rightDigit == 0) { return; }
            if (rightDigit == 0)
            {
                leftDigit -= 1;
                rightDigit = 9;
            }
            else
            {
                rightDigit -= 1;
            }
            digitTwo.Text = leftDigit.ToString();
            digitOne.Text = rightDigit.ToString();
            BoundCharacter.AttributePoints += attributeCost;

        }


        /// <summary>
        /// Increases the specified labels to reflect the user's choice
        /// </summary>
        /// <param name="attributeCost">The cost of the current attribute.</param>
        /// <param name="leftDigit">The left digit as an integer.</param>
        /// <param name="rightDigit">The right digit as an integer.</param>
        /// <param name="digitTwo">The left digit as a label.</param>
        /// <param name="digitOne">The right digit as a label.</param>
        private void IncreaseAttributeLabel(int leftDigit, int rightDigit, Label digitTwo, Label digitOne)
        {
            // To check cost of next attribute
            int attributeCost = Character.CalculateAttributeCost(int.Parse(digitTwo.Text + digitOne.Text) + 1);

            // Simple checks to update labels accurately
            if ((BoundCharacter.AttributePoints - attributeCost < 0) || (leftDigit == 2 && rightDigit == 0)) { return; }

            if (rightDigit == 9)
            {
                leftDigit += 1;
                rightDigit = 0;
            }
            else
            {
                rightDigit += 1;
            }

            digitTwo.Text = leftDigit.ToString();
            digitOne.Text = rightDigit.ToString();
            BoundCharacter.AttributePoints -= attributeCost;
        }


        #endregion

        #region Cleanup

        /// <summary>
        /// Saves character properties based on correspondinf controls, then adds
        /// bound character to static list of character's if it's not already there.
        /// </summary>
        private void SaveCharacter()
        {
            // Set character properties
            BoundCharacter.Name = tbxName.Text;
            BoundCharacter.Gender = (Gender)Enum.Parse(typeof(Gender), cbxGender.Text);
            BoundCharacter.ArmourClass = (int)nudArmourClass.Value;
            BoundCharacter.ExperiencePoints += (int)nudXP.Value;
            BoundCharacter.Class = Class.FindByName(cbxClass.Text);
            BoundCharacter.Race = Race.FindByName(cbxRace.Text);
            BoundCharacter.Alignment = (Alignment)Enum.Parse(typeof(Alignment), cbxAlignment.Text);

            // Save attributes
            SaveCharacterAttributes();

            // Save character to memory
            if (!Character.Characters.Contains(BoundCharacter)) { Character.Characters.Add(BoundCharacter); ; }
           
            // Close form
            Close();
        }

        /// <summary>
        /// Saves character attributes based on attribute labels.
        /// </summary>
        private void SaveCharacterAttributes()
        {
            if (BoundCharacter.Attributes == null) { return; }
            BoundCharacter.Attributes[Constants.Attribute.Strength] = int.Parse(lblStrengthDigitTwo.Text + lblStrengthDigitOne.Text);
            BoundCharacter.Attributes[Constants.Attribute.Dexterity] = int.Parse(lblDexterityDigitTwo.Text + lblDexterityDigitOne.Text);
            BoundCharacter.Attributes[Constants.Attribute.Constitution] = int.Parse(lblConstitutionDigitTwo.Text + lblConstitutionDigitOne.Text);
            BoundCharacter.Attributes[Constants.Attribute.Intelligence] = int.Parse(lblIntelligenceDigitTwo.Text + lblIntelligenceDigitOne.Text);
            BoundCharacter.Attributes[Constants.Attribute.Wisdom] = int.Parse(lblWisdomDigitTwo.Text + lblWisdomDigitOne.Text);
            BoundCharacter.Attributes[Constants.Attribute.Charisma] = int.Parse(lblCharismaDigitTwo.Text + lblCharismaDigitOne.Text);
        }

        #endregion



    }
}

#endregion
