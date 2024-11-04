/*
 * Title: frmGenericDescriptor.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-03
 * Purpose: To provide a generic info form for displaying race/class descriptions.
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

#endregion

#region Namespace Definition

namespace Assignment3.Forms
{
    /// <summary>
    /// A generic class for displaying d&d text information.
    /// </summary>
    public partial class frmGenericDescriptor : Form
    {
        /// <summary>
        /// Default constructor displays no data
        /// </summary>
        public frmGenericDescriptor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Paramaterized constructor displays provided data
        /// </summary>
        /// <param name="description">The text to display</param>
        public frmGenericDescriptor(string description)
        {
            InitializeComponent();
            InitializeForm(description);
        }


        /// <summary>
        /// Sets label to matching description
        /// </summary>
        /// <param name="description">Description to update label with</param>
        private void InitializeForm(string description)
        {
            lblDescription.Text = description;
        }
    }
}

#endregion