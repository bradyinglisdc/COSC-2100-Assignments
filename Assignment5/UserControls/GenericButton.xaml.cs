/*
 * Title: GenericButton.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-04
 * Purpose: A child of the border class; the purpose of this class is to provide a generic template for easy to modify buttons.
 *          Rather then overriding a button's template, this class can be used to more efficiently apply styling.
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
    /// Interaction logic for GenericButton.xaml
    /// </summary>
    public partial class GenericButton : Border 
    {

        #region Instance Properties

        /// <summary>
        /// As the border class does not have a non-routed event, this custom Click event
        /// basically ensures the event can be invoked from within the class itself.
        /// </summary>
        public event EventHandler? Click;

        /// <summary>
        /// Gets and sets the content of the border's text block
        /// </summary>
        public string Content
        {
            get { return tboContent.Text; }
            set { tboContent.Text = value; }
        }

        /// <summary>
        /// Gets and sets the foreground of the border's text block
        /// </summary>
        public Brush Foreground
        {
            get { return tboContent.Foreground; }
            set { tboContent.Foreground = value; }
        }

        /// <summary>
        /// Gets and sets the content property of the hidden Button (btnHidden associated with this class instance.
        /// This is required such that the parent properties click event can be triggered through a shortcut.
        /// </summary>
        public string? Shortcut
        {
            get { return btnHidden.Content.ToString(); }
            set { btnHidden.Content = value; }
        }

        /// <summary>
        /// Gets and sets the IsCancel property of the hidden button
        /// </summary>
        public bool IsCancel
        {
            get { return btnHidden.IsCancel; }
            set { btnHidden.IsCancel = value; }
        }

        /// <summary>
        /// Gets and sets the IsDefault property of the hidden button
        /// </summary>
        public bool IsDefault
        {
            get { return btnHidden.IsDefault; }
            set { btnHidden.IsDefault = value; }
        }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Simply parses associated xaml
        /// </summary>
        public GenericButton()
        {
            InitializeComponent();
            SubscribeEventHandlers();
        }

        #region Event Handlers

        /// <summary>
        /// Invokes click event for this instance.
        /// </summary>
        /// <param name="sender">The button which had it's shortcut pressed</param>
        /// <param name="e">Event args</param>
        private void btnHidden_Click(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invokes the clicke event for this instance.
        /// </summary>
        /// <param name="sender">This control, which was clicked.</param>
        /// <param name="e">Event args</param>
        private void Main_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Setup 

        /// <summary>
        /// Subscribes appropriate methods to btnHidden.Click and MouseLeftButtonDown events,
        /// such that they both invoke the generic .Click event
        /// </summary>
        private void SubscribeEventHandlers()
        {
            btnHidden.Click += btnHidden_Click;
            MouseLeftButtonDown += Main_MouseLeftButtonDown;
        }

        #endregion

        #endregion
    }
}

#endregion