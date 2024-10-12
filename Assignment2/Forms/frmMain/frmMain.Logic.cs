/*
 * Title: frmMain.Logic.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-11
 * Purpose: To connect front end logic of frmMain to backend logic of BS class and GameState class.
 */

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace Definition
namespace Assignment2
{

    /// <summary>
    /// This class will simply contain the methods called from
    /// frmMain.cs. It serves as a connection of the back end and front end,
    /// such that when a front end event happens, the back end is updated.
    /// </summary>
    public partial class frmMain
    {
        #region Game Logic

        /// <summary>
        /// Prompts user to select difficulty before starting game.
        /// </summary>
        public void StartGame()
        {
            // Removes start game prompt - it should never need to appear again.
            if (!CurrentGameState.GameHappening) { pnlGameArea.Controls.Remove(lblStartGamePrompt); }
            
            // Resets game state and board state (ship health, BS class arrays)
            CurrentGameState.Reset();

            // Sets up game area
            SetupGameBoard();
        }

        /// <summary>
        /// Sets/Resets board to default
        /// </summary>
        private void SetupGameBoard()
        {
            // Add and styles/re-style labels, set default board up
            CurrentGameState.SetDefaultBoard(pnlGameArea);
            SetupGameControls();
            StyleActiveGamePositioning();
        }

        /// <summary>
        /// Makes all game related controls (misslesFired, manualControls, and pnlProgress)
        /// visible by bringing them to the front, then calls their update methods to display
        /// the current progress
        /// </summary>
        private void SetupGameControls()
        {
            pbxMissilesFired.BringToFront();
            pnlProgress.BringToFront();
            pnlManualControls.BringToFront();
            UpdateProgress();
        }

        /// <summary>
        /// Simply updates each front end game tracker to display accurate information.
        /// </summary>
        private void UpdateProgress()
        {
            UpdateMissilesFiredLabel();
            UpdateGameProgress();
            DisplayWin();
        }

        /// <summary>
        /// Updates front end to reflect boat hits.
        /// </summary>
        private void UpdateGameProgress()
        {
            UpdateProgressControlGroup(lblCarrierHealthHeader, pbrCarrierHealthIndicator, CurrentGameState.CarrierHealth, BS.Boats.Carrier);
            UpdateProgressControlGroup(lblBattleshipHealthHeader, pbrBattleshipHealthIndicator, CurrentGameState.BattleshipHealth, BS.Boats.Battleship);
            UpdateProgressControlGroup(lblCruiserHealthHeader, pbrCruiserHealthIndicator, CurrentGameState.CruiserHealth, BS.Boats.Cruiser);
            UpdateProgressControlGroup(lblSubmarineHealthHeader, pbrSubmarineHealthIndicator, CurrentGameState.SubmarineHealth, BS.Boats.Submarine);
            UpdateProgressControlGroup(lblDestroyerHealthHeader, pbrDestroyerHealthIndicator, CurrentGameState.DestroyerHealth, BS.Boats.Destroyer);
        }

        /// <summary>
        /// Updates a label and progress based on the health of a given ship.
        /// </summary>
        /// <param name="boatHeader">The boat type and hit progress.</param>
        /// <param name="boatProgress">The destruction progress bar.</param>
        /// <param name="boatHealth">The boat's remainining health.</param>
        /// <param name="boatType">The boat type.</param>
        private void UpdateProgressControlGroup(Label boatHeader, ProgressBar boatProgress, int boatHealth, BS.Boats boatType)
        {
            double boatSize = BS.GetBoatSize(boatType);
            double health = boatHealth;
            boatHeader.Text = $"{boatType.ToString()} ({boatSize - boatHealth}/{boatSize} Hits)";

            // Avoid dividing by 0
            if (boatSize - boatHealth == 0) { boatProgress.Value = 0; }
            else { boatProgress.Value = (int)(((boatSize - health) / boatSize) * 100.0); }
        }

        /// <summary>
        /// Updates missles fired labale to accurately reflect user's turns.
        /// </summary>
        private void UpdateMissilesFiredLabel()
        {
            lblMissilesFired.Text = $"MISSILES FIRED: {CurrentGameState.MissilesFired}\nBOATS SUNK: {CurrentGameState.GetBoatsSunk()}";
        }

        #endregion

        #region Cleanup/Ending Methods

        /// <summary>
        /// Prompt the user to start a new game/exit if they win.
        /// </summary>
        private void DisplayWin()
        {
            if (CurrentGameState.CheckForWin()) { new frmWinningScreen(this).ShowDialog(); }
        }

        /// <summary>
        /// Closes the form if the user agrees to the prompt.
        /// </summary>
        public void ExitApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit the application? None of your game data will save.", "Exit Battleship?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
#endregion