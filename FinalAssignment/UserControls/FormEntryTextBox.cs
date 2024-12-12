/*
 * Title: FormEntryTextBox.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-04
 * Purpose: A child of the border class; the purpose of this class is essentially to provide a textbox with more customizability.
 *          The outer control is a border, nested within that is a grid, followed by a text box and a text block for placeholder text.
*/

#region Namespaces Used

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// A more customizable text box. This control includes border radius control, as well placeholder text control.
    /// </summary>
    class FormEntryTextBox : Border
    {

        #region Instance Properties

        #region User Accessible

        /// <summary>
        /// Gets and sets the content string of this text box.
        /// Abstracts actual textbox away from user.
        /// </summary>
        public string Content
        {
            get { return tbxContent.Text; }
            set { tbxContent.Text = value; }
        }

        /// <summary>
        /// Gets the string value of this instances placeholder text.
        /// Sets the string value of this instances place holder text, then updates the corresponding control.
        /// </summary>
        public string Placeholder
        {
            get { return tboPlaceholder.Text; }
            set { tboPlaceholder.Text = value; }
        }

        /// <summary>
        /// Gets and sets the value of the text wrapping property witin the text box content.
        /// </summary>
        public TextWrapping TextWrapping
        {
            get { return tbxContent.TextWrapping; }
            set { tbxContent.TextWrapping = value; }
        }

        /// <summary>
        /// Gets and sets accept return bool
        /// </summary>
        public bool AcceptsReturn
        {
            get { return tbxContent.AcceptsReturn; }
            set { tbxContent.AcceptsReturn = value; }
        }

        /// <summary>
        /// Gets and sets foreground of main content
        /// </summary>
        public Brush Foreground
        {
            get { return tbxContent.Foreground; }
            set { tbxContent.Foreground = value; }
        }

        /// <summary>
        /// Gets amd sets foreground of placeholder
        /// </summary>
        public Brush PlaceholderForeground
        {
            get { return tboPlaceholder.Foreground; }
            set { tboPlaceholder.Foreground = value; }
        }

        #endregion

        #region Controls

        /// <summary>
        /// Container of the TextBox, and placeholder Textblock
        /// </summary>
        protected Grid grdContainer { get; set; } = new Grid();

        /// <summary>
        /// Gets the actual textbox for this control.
        /// </summary>
        protected TextBox tbxContent { get; } = new TextBox();


        /// <summary>
        /// To be called from Placeholder setter.
        /// Gets this instances placeholder text block value.
        /// </summary>
        protected TextBlock tboPlaceholder { get; } = new TextBlock();

        #endregion

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Default constructor calls the base border constructor to initalize the object, then sets additional controls.
        /// </summary>
        public FormEntryTextBox() : base()
        {
            AddChildren();
            SetDefaultStyles();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Adds child controls to respective parents
        /// </summary>
        private void AddChildren()
        {
            // Main control is a single grid container; just gets the grid container
            Child = grdContainer;

            // Grid gets actual content and placeholder
            grdContainer.Children.Add(tboPlaceholder);
            grdContainer.Children.Add(tbxContent);
        }

        /// <summary>
        /// Makes textbox background transparent, such that the background is deligated to the border,
        /// aligns text vertically, and subscribes to tbxContent got/lost focus event such that the place
        /// holder is made invisble when user types.
        /// </summary>
        private void SetDefaultStyles()
        {
            tbxContent.Background = Brushes.Transparent;
            tbxContent.Padding = new Thickness(5, 0, 0, 0);
            tbxContent.VerticalAlignment = VerticalAlignment.Center;
            tbxContent.BorderThickness = new Thickness(0);
            tbxContent.Foreground = Brushes.White;

            tbxContent.GotFocus += new RoutedEventHandler(ChangePlaceholderVisibility);
            tbxContent.LostFocus += new RoutedEventHandler(ChangePlaceholderVisibility);

            tboPlaceholder.Padding = new Thickness(5, 0, 0, 0);
            tboPlaceholder.VerticalAlignment = VerticalAlignment.Center;
            tboPlaceholder.Foreground = new SolidColorBrush(Color.FromArgb(190,0,0,0));
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
            if (tbxContent.Text.Length > 0) { return; }

            tboPlaceholder.Visibility = tboPlaceholder.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        #endregion

    }
}

#endregion