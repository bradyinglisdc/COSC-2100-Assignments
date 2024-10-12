/*
 * Title: frmWinningScreen.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-09
 * Purpose: Simply displays the amount of Missiles fired to achieve a win,
 * then allows user to play again.
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
    /// This class serves to display how many Missiles were fired in the game, 
    /// and allow the user to start another game or exit.
    /// </summary>
    public partial class frmWinningScreen : Form
    {
        #region Properties
        private frmMain frmLinkedForm { get; set; }
        #endregion

        /// <summary>
        /// Updates properties based on main form.
        /// </summary>
        /// <param name="frmMain">The corresponding main form to pull properties from.</param>
        public frmWinningScreen(frmMain frmMain)
        {
            InitializeComponent();
            frmLinkedForm = frmMain;
            SetStats();
        }

        #region Setup Methods

        /// <summary>
        /// Simply sets the stats to correspond to the properties in frmMain
        /// </summary>
        private void SetStats()
        {
            GameState gameState = frmLinkedForm.CurrentGameState;
            lblGamesWon.Text = $"Games Won: {gameState.GameScores.Count}";
            lblAvgScore.Text = $"Average Score: {gameState.AverageScore}";
            lblScore.Text = $"Score: {gameState.GameScores[gameState.GameScores.Count - 1]}";
            lblMissilesFired.Text = $"Missiles Fired: {gameState.MissilesFired}";
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Starts another game using the linked form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Close();
            frmLinkedForm.StartGame();
        }

        /// <summary>
        /// Calls method to exit appliation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        #endregion

        #region Cleanup Methods

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

        #endregion

 
    }
}
#endregion
