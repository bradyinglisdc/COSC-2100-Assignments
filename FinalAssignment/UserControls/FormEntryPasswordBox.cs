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
using System.Windows.Input;

#endregion

#region Namespace Definition

namespace FinalAssignment
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
        /// True if password should be shown.
        /// </summary>
        public bool Show
        {
            get { return _show; }
            set
            {
                _show = value;
                SetShow();
            }
        }

        /// <summary>
        /// Gets and sets pbxContent's foreground.
        /// </summary>
        public Brush PasswordForeground
        {
            get { return pbxContent.Foreground; }
            set { pbxContent.Foreground = value; }
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
        /// Ensures password box and text box hold same values.
        /// </summary>
        private void Content_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbxContent.Text == pbxContent.Password) { return; }
            tbxContent.Text = pbxContent.Password;
        }

        /// <summary>
        /// Ensures password box and text box hold same values.
        /// </summary>
        private void Content_TextChanged(object sender, RoutedEventArgs e)
        {
            if (tbxContent.Text == pbxContent.Password) { return; }
            pbxContent.Password = tbxContent.Text;
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
            pbxContent.Foreground = Brushes.White;

            pbxContent.GotFocus += ChangePlaceholderVisibility;
            pbxContent.LostFocus += ChangePlaceholderVisibility;

            // If the password should be numeric, remove non numeric keys on password change
            pbxContent.PasswordChanged += Content_PasswordChanged;
            tbxContent.TextChanged += Content_TextChanged;

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
            }
            else
            {
                pbxContent.Visibility = Visibility.Visible;
                tbxContent.Visibility = Visibility.Hidden;
            }
        }

        #endregion

    }
}

#endregion