/*
 * Title: Smartphone.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-17
 * Purpose: To define an instantiatable Smartphone class.
 */

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion  

#region Namespace Definition
namespace ClassExercise2
{

    /// <summary>
    /// An instantiatable Smartphone object. Contains various static and non static data members
    /// to encapsulate a Smartphone. 
    /// 
    /// As of right now, all properties are made nullable (data type marked with ?) such that 
    /// compiler warnings are not triggered when default constructor is called, as it expects
    /// property setters to be called directly within every constructor instead of sub-methods.
    /// </summary>
    public class Smartphone
    {
        #region Static Variables and Constants

        #region Constants

        private const string DEFAULT_MANUFACTURER = "None";
        private const string DEFAULT_PHONE_NAME = "None";
        private const int DEFAULT_MODEL_NUMBER = 0;
        private const int DEFAULT_BATTERY_LIFE = 100;
        private const string? DEFAULT_PHONE_NUMBER = "000-000-0000";
        private const int DEFAULT_STORAGE = 50;

        #endregion

        #region Identification and Tracking

        private static char[] CurrentSerialCodeAlpha = { 'A', 'A', 'A', 'A', 'A' };
        private static int CurrentSerialCodeNumeric = 0;
        private static List<Smartphone> Smartphones = new List<Smartphone>();

        #endregion

        #endregion

        #region Backing Data Members

        private string? _serialCode;
        private int _batteryLife;
        private int _storage;

        #endregion

        #region Properties

        #region Identification

        public string? Manufacturer { get; set; }
        public string? PhoneName { get; set; }
        public int ModelNumber { get; set; }

        /// <summary>
        /// Auto number identity. Sets serial code in format: AAAAA-0000.
        /// Once right side digit passes 9999, the closest character 
        /// iterates up (e.g. AAAAA-9999 -> AAAAB-0000).
        /// </summary>
        public string? SerialCode{ get; private set; }

        #endregion

        #region Phone Details

        /// <summary>
        /// Gets and sets the phone number for this phone.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets and sets the Apps List for this phone.
        /// The key is a string representing the app name, the value is the storage for that app.
        /// Setter is private so that custom method can subtract storage as apps are added;
        /// an apps list should never be set outside this class.
        /// </summary>
        public Dictionary<string, int>? Apps { get; private set; }

        /// <summary>
        /// Gets and sets the storage for this phone in GB.
        /// </summary>
        public int Storage
        {
            get { return _storage; }
            set
            {
                if (_storage - value < 0) { _storage = 0; }
                else { _storage = value; }
            }
        }

        /// <summary>
        /// Gets and sets the Contacts Dictionary for this phone.
        /// </summary>
        public Dictionary<string, int>? Contacts { get; set; }

        /// <summary>
        /// Gets the battery life of the phone. Sets the battery life if the value passed in is 
        /// in the correct range, otherwise sets to default.
        /// </summary>
        public int BatteryLife
        {
            get { return _batteryLife; }
            set
            {
                if (value > 100 || value < 0) { _batteryLife = DEFAULT_BATTERY_LIFE; }
                else { _batteryLife = value; }
            }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - sets up default values for a generic Smartphone.
        /// </summary>
        public Smartphone()
        {
            SetDefaults();
        }

        /// <summary>
        /// Parameterized constructor - sets values based on the passed in parameters.
        /// </summary>
        /// <param name="manufacturer">The phone manufacturer</param>
        /// <param name="phoneName">The name of the phone (e.g. IPhone)</param>
        /// <param name="modelNumber">The model number</param>
        /// <param name="phoneNumber">The phone number of this phone</param>
        /// <param name="storage">The storage capacity in GB of this phone</param>
        ///<param name="batteryLife">The battery life of this phone</param>
        /// <param name="apps">Dictionary for each app to add (appName: appSizeInGB)</param>
        /// <param name="contacts">Dictionary for each contact to add (contactName: contactNumber)</param>
        public Smartphone(string manufacturer, string phoneName, int modelNumber, string phoneNumber, 
            int storage, int batteryLife, Dictionary<string, int> apps, Dictionary<string, int> contacts)
        {
            Manufacturer = manufacturer;
            PhoneName = phoneName;
            ModelNumber = modelNumber;
            PhoneNumber = phoneNumber;
            Storage = storage;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Simply sets this smartphone's properties to defaults.
        /// </summary>
        private void SetDefaults()
        {
            Manufacturer = DEFAULT_MANUFACTURER;
            PhoneName = DEFAULT_PHONE_NAME;
            ModelNumber = DEFAULT_MODEL_NUMBER;
            
            SerialCode = NextSerialCode();
            PhoneNumber = DEFAULT_PHONE_NUMBER;
            Apps = new Dictionary<string, int>();
            Contacts = new Dictionary<string, int>();
            Storage = DEFAULT_STORAGE;
            BatteryLife = DEFAULT_BATTERY_LIFE;
        }

        #endregion

        #region Static Methods

        #region Auto Incrementation

        /// <summary>
        /// Contains an algorithm which determines the next alpha-numeric serial code,
        /// and auto updates it's static value.
        /// AAAAA-9999 -> AAAAB-0000
        /// </summary>
        /// <returns>The next serial code.</returns>
        private static string NextSerialCode()
        {

            // Just iterate numeric value if it hasn't reached 9999 yet
            if (CurrentSerialCodeNumeric != 9999) { CurrentSerialCodeNumeric++; }

            // Otherwise, update the numeric value to 0000 and get the next alpha portion of the code
            else 
            { 
                CurrentSerialCodeNumeric = 0000;
                NextSerialCodeAlpha();
            }

            // Return the code 
            return $"{new String(CurrentSerialCodeAlpha)}-{CurrentSerialCodeNumeric}";
        }

        /// <summary>
        /// Auto updates the alphabetic portion of the serial code.
        /// </summary>
        private static void NextSerialCodeAlpha()
        {

            // If the alpha portion has reached the maximum (ZZZZZ), just return.
            if (new String(CurrentSerialCodeAlpha) == "ZZZZZ") {  return; }

            // If right most char is Z, recursively update each char starting from right side
            if (CurrentSerialCodeAlpha[^1] == 'Z') { UpdateSerialCodeCharacters(CurrentSerialCodeAlpha.Length - 1); }

            // Otherwise, just add one to the ascii value of the right most char
            else
            {
                CurrentSerialCodeAlpha[^1] = (char)((int)CurrentSerialCodeAlpha[^1] + 1);
            }

        }

        /// <summary>
        /// Recursively calls itself if a character is Z, and the character
        /// to the left of it is Z
        /// </summary>
        /// <param name="currentCharIndex">The index we are checking.</param>
        /// <returns>The updated CurrentSerialCodeAlpha</returns>
        private static char[] UpdateSerialCodeCharacters(int currentCharIndex)
        {
            // The base case: stop checking if first char is reached 

            if (currentCharIndex != 0)
            {
                if (CurrentSerialCodeAlpha[currentCharIndex] == 'Z' && CurrentSerialCodeAlpha[currentCharIndex - 1] == 'Z')
                {
                    CurrentSerialCodeAlpha[currentCharIndex] = 'A';
                }

                // If just this character is Z and the character to the right is Z, just update this one to A
                // and the left one to it's next ascii character value,
                else if (CurrentSerialCodeAlpha[currentCharIndex] == 'Z')
                {
                    CurrentSerialCodeAlpha[currentCharIndex] = 'A';
                    CurrentSerialCodeAlpha[currentCharIndex - 1] = ((char)((int)CurrentSerialCodeAlpha[currentCharIndex - 1] + 1));
                }

                UpdateSerialCodeCharacters(currentCharIndex - 1);
            }
            return CurrentSerialCodeAlpha;
        }

        #endregion

        #region Search

        /// <summary>
        /// Searches through static list of Smartphone for a match.
        /// </summary>
        /// <returns>A Smartphone if there is a match, else a default smartphone.</returns>
        /// <param name="serialCode">Serial code of Smartphone to be found.</param>
        public static Smartphone FindBySerialCode(string serialCode)
        {
            foreach(Smartphone phone in Smartphones)
            {
                if (phone.SerialCode == serialCode) { return phone; }
            }
            return new Smartphone();
        }

        #endregion

        #endregion
    }
}

#endregion
