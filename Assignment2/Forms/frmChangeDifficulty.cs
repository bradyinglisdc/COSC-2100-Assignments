/*
 * Title: frmChangeDifficulty.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-13
 * Purpose: To provide a simple interface for setting a battleship game difficulty.
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

namespace Assignment2
{
    /// <summary>
    /// This class simply allows the user to set the difficulty of a battleship game using a corresponding
    /// game state.
    /// </summary>
    public partial class frmChangeDifficulty : Form
    {

        #region Properties

        GameState CurrentGameState { get; set; }

        #endregion


        #region Constructor(s)

        /// <summary>
        /// Sets the CurrentGameState property to the corresponding game state.
        /// </summary>
        /// <param name="gameState">The gameState to use.</param>
        public frmChangeDifficulty(GameState gameState)
        {
            InitializeComponent();
            CurrentGameState = gameState;
        }

        #endregion


        #region Event Handler Methods

        /// <summary>
        /// Simply calls method to determine if entire application should exit, or just form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        #endregion

        #region Form Logic

        /// <summary>
        /// Calls a method to set the difficulty of the CurrentGameStateProperty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            SetDifficulty();
        }

        /// <summary>
        /// Sets the difficulty of the curret game state property then exits.
        /// </summary>
        private void SetDifficulty()
        {
            // Set difficulty
            if (rbtnEasy.Checked) { CurrentGameState.Difficulty = Difficulty.Easy; }
            else { CurrentGameState.Difficulty = Difficulty.Hard; }

            // Exit with OK result
            DialogResult = DialogResult.OK;
            CloseForm();
        }

        #endregion

        #region Cleanup Methods

        /// <summary>
        /// Checks if the current game state has a win already.
        /// If it does, this method should close the application.
        /// Otherwise, this method should just close the form.
        /// </summary>
        private void Exit()
        {
            if (CurrentGameState.CheckForWin()) { CloseApplication(); }
            else { CloseForm(); }
        }

        /// <summary>
        /// Prompts user before closing linked form and this.
        /// </summary>
        private void CloseApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit the application? None of your game data will save.",
                "Exit Battleship?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }

            // Ensure form doen't auto close on escape key
            DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Just closes this form instance.
        /// </summary>
        private void CloseForm()
        {
            Close();
        }

        #endregion
    }
}

#endregion