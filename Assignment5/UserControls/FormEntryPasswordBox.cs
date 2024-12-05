/*
 * Title: FormEntryPasswordBox.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-04
 * Purpose: A child of the border class; the purpose of this class is essentially to provide a passwordbox with more customizability.
 *          The outer control is a border, nested within that is a grid, followed by a password box and a text block for placeholder text.
*/

#region Namespaces Used

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#endregion

#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// A more customizable text box. This control includes border radius control, as well placeholder text control.
    /// </summary>
    class FormEntryPasswordBox : FormEntryTextBox
    {

        #region Private Backing Members

        private bool _show;

        #endregion

        #region Instance Properties

        #region User Accessible

        /// <summary>
        /// Gets and sets the maximum password length. Default is 0.
        /// </summary>
        public int MaximumLength
        {
            get { return pbxContent.MaxLength; }
            set 
            { 
                pbxContent.MaxLength = value;
                tbxContent.MaxLength = value;    
            }
        }

        /// <summary>
        /// Gets and sets numeric value; true if passkey should be only numeric
        /// </summary>
        public bool Numeric { get; set; }

        public bool Show
        {
            get { return _show; }
            set
            {
                _show = value;
                SetShow();
            }
        }


        #endregion

        #region Controls

        /// <summary>
        /// Gets the actual passwordbox for this control.
        /// </summary>
        private PasswordBox pbxContent { get; } = new PasswordBox();

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor calls the base border constructor to initalize the object, then sets additional controls.
        /// </summary>
        public FormEntryPasswordBox() : base()
        {
            AddChildren();
            SetDefaultStyles();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Negates placeholder visibility
        /// </summary>
        /// <param name="sender">The text box which changed</param>
        /// <param name="e">Event args</param>
        private void ChangePlaceholderVisibility(object sender, EventArgs e)
        {
            // Just return if text has already been entered
            if (pbxContent.Password.Length > 0) { return; }

            tboPlaceholder.Visibility = tboPlaceholder.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        /// <summary>
        /// Removes any non numeric keys when a numeric password is changed.
        /// </summary>
        private void Content_PasswordChanged(object sender, EventArgs e)
        {
            EnsureNumeric();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Adds child controls to respective parents
        /// </summary>
        private void AddChildren()
        {
            grdContainer.Children.Add(pbxContent);
        }

        /// <summary>
        /// Makes textbox background transparent, such that the background is deligated to the border,
        /// aligns text vertically, and subscribes to pbxContent got/lost focus event such that the place
        /// holder is made invisble when user types.
        /// </summary>
        private void SetDefaultStyles()
        {
            pbxContent.Background = Brushes.Transparent;
            pbxContent.Padding = new Thickness(5, 0, 0, 0);
            pbxContent.VerticalAlignment = VerticalAlignment.Center;
            pbxContent.BorderThickness = new Thickness(0);

            pbxContent.GotFocus += new RoutedEventHandler(ChangePlaceholderVisibility);
            pbxContent.LostFocus += new RoutedEventHandler(ChangePlaceholderVisibility);

            // If the password should be numeric, remove non numeric keys on password change
            pbxContent.PasswordChanged += new RoutedEventHandler(Content_PasswordChanged);
            tbxContent.TextChanged += new TextChangedEventHandler(Content_PasswordChanged);

            // Derived class text box is hidden unless password should be shown.
            tbxContent.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Logic

        /// <summary>
        /// Shows or hides password based on Show value
        /// Ensures text box and password box match.
        /// </summary>
        private void SetShow()
        {
            if (Show) 
            { 
                pbxContent.Visibility = Visibility.Hidden;
                tbxContent.Visibility = Visibility.Visible;
                tbxContent.Text = pbxContent.Password;
            }
            else
            {
                pbxContent.Visibility = Visibility.Visible;
                tbxContent.Visibility = Visibility.Hidden;
                pbxContent.Password = tbxContent.Text;
            }
        }

        /// <summary>
        /// Ensures all characters are numeric, if Numeric is true
        /// </summary>
        private void EnsureNumeric()
        {
            // Just return if non numeric
            if (!Numeric) { return; }

            // Remove all non-numerics from password and textbox
            if (ContainsNonNumerics(pbxContent.Password) || ContainsNonNumerics(tbxContent.Text))
            {
                pbxContent.Password = RemoveNonNumerics(pbxContent.Password);
                tbxContent.Text = RemoveNonNumerics(tbxContent.Text);
            }
        }

        /// <summary>
        /// Checks if a string contains non numeric values.
        /// </summary>
        /// <param name="content">String to search through</param>
        /// <returns>True if the value contains non numerics</returns>
        private bool ContainsNonNumerics(string content)
        {
            foreach (char character in content)
            {
                if (!char.IsNumber(character)) { return true; ; }
            }
            return false;
        }

        /// <summary>
        /// Ensures all characters in a string are numeric, returns result
        /// </summary>
        /// <param name="strToChange">The string to remove numerics from</param>
        /// <returns>The numeric only string</returns>s
        private static string RemoveNonNumerics(string strToChange)
        {
            foreach (char character in strToChange)
            {
                if (!char.IsNumber(character)) { strToChange = strToChange.Replace($"{character}", ""); }
            }
            return strToChange;
        }

        #endregion

    }
}

#endregion