/*
 * Title: GameState.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-06
 * Purpose: To capture variables related to, and provide logic bridge between front and back-end for a battleship game instance.
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
    /// This class keeps track of game win conditions and boat health
    /// </summary>
    public class GameState
    {
        #region Properties
        public Label[,] BoardArray { get; set; }
        public int CarrierHealth { get; set; }
        public int BattleshipHealth { get; set; }
        public int SubmarineHealth { get; set; }
        public int CruiserHealth { get; set; }
        public int DestroyerHealth { get; set; }
        public bool GameHappening { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MissilesFired { get; set; }
        public List<int> GameScores { get; set; }
        public int AverageScore { get; set; }
        private ToolTip ToolTips { get; set; }
        private EventHandler BoardPositionFrontend_Click { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Simply insantiates game related field.
        /// For design purposes, this constructor takes in frmMain's matching tool tip property,
        /// as well as it's board position click event handler so that it can be subscribed/unsubscribed with ease.
        /// </summary>
        /// <param name="toolTips">Front end ToolTips property.</param>
        /// <param name="HandlerboardPositionFrontend_Click">Front end board position click event handler.</param>
        public GameState(ToolTip toolTips, EventHandler boardPositionFrontend_Click)
        {
            // Store the front end's ToolTips and board position click event handler.
            ToolTips = toolTips;
            BoardPositionFrontend_Click = boardPositionFrontend_Click;

            // Tracking related propeties
            SetBoatHealth();
            Difficulty = Difficulty.Easy; // Default difficulty is easy
            BoardArray = BS.GetBoardAsLabelArray();
            MissilesFired = 0;
            GameScores = new List<int>();
            AverageScore = 0;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Calls method to fire a missle at boardPosition's coordinates.
        /// </summary>
        /// <param name="sender">The boardPosition label.</param>
        /// <param name="e">Any arguments added.</param>
        private void BoardPosition_Click(object? sender, EventArgs e)
        {
            // Ensure sender is label before explicit cast
            if (!(sender is Label)) { return; }
            FireMissle((Label)sender);
        }

        #endregion

        #region Progress Tracking

        /// <summary>
        /// Sets health of all boats back to full.
        /// </summary>
        private void SetBoatHealth()
        {
            CarrierHealth = BS.GetBoatSize(BS.Boats.Carrier);
            BattleshipHealth = BS.GetBoatSize(BS.Boats.Battleship);
            SubmarineHealth = BS.GetBoatSize(BS.Boats.Submarine);
            CruiserHealth = BS.GetBoatSize(BS.Boats.Cruiser);
            DestroyerHealth = BS.GetBoatSize(BS.Boats.Destroyer);
        }

        /// <summary>
        /// Tallys up sunken boats based on health.
        /// </summary>
        /// <returns>Integer representing number of sunken boats.</returns>
        public int GetBoatsSunk()
        {
            int sunkenBoats = 0;
            sunkenBoats += CheckBoatStatus(CarrierHealth);
            sunkenBoats += CheckBoatStatus(BattleshipHealth);
            sunkenBoats += CheckBoatStatus(SubmarineHealth);
            sunkenBoats += CheckBoatStatus(CruiserHealth);
            sunkenBoats += CheckBoatStatus(DestroyerHealth);

            return sunkenBoats;
        }

        /// <summary>
        /// Returns Checks if a given boat is sunk based off health.
        /// </summary>
        /// <param name="boatHealth">The boat to check.</param>
        /// <returns>1 if boat is sunk, 0 if boat is alive.</returns>
        private int CheckBoatStatus(int boatHealth)
        {
            if (boatHealth == 0) { return 1; }
            return 0;
        }

        #endregion

        #region Game Setup

        /// <summary>
        /// Adds each label (BoardPositions) to pnlGameArea, as well as some default properties
        /// that should only be set once when the game is started, as well as event handlers.
        /// </summary>
        /// <param name="pnlGameArea">The game area to populate with labels.</param>
        public void SetDefaultBoard(Panel pnlGameArea)
        {
            // Clears and updates board array so it's size is reflective of the difficulty
            ClearBoardPositions(pnlGameArea);
            BoardArray = BS.GetBoardAsLabelArray();

            // Get the sizing based on difficulty
            frmMain.MaximumBoardPositionSize = Difficulty == Difficulty.Easy ? frmMain.MAXIMUM_BOARD_POSITION_SIZE_EASY : frmMain.MAXIMUM_BOARD_POSITION_SIZE_HARD;

            // Iterates through board array, updating status to default
            foreach (Label boardPosition in BoardArray)
            {
                ToolTips.SetToolTip(boardPosition, $"Click here to fire a missle!");
                boardPosition.Click += new EventHandler(BoardPosition_Click);
                boardPosition.Click += BoardPositionFrontend_Click;
                boardPosition.BackColor = Color.FromArgb(255, 10, 10, 10);
                boardPosition.MaximumSize = new Size(frmMain.MaximumBoardPositionSize, frmMain.MaximumBoardPositionSize);
                pnlGameArea.Controls.Add(boardPosition); 
                boardPosition.BringToFront();
            }
        }

        /// <summary>
        /// Searches through board array and clears all labels.
        /// </summary>
        /// <param name="pnlGameArea">The game area to wipe.</param>
        private void ClearBoardPositions(Panel pnlGameArea)
        {
            foreach (Label boardPosition in BoardArray)
            {
                pnlGameArea.Controls.Remove(boardPosition);
            }
        }

        #region Game Logic

        /// <summary>
        /// Gets the coordinates of the label to fire on, then proceeds to attempt to fire.
        /// Updates board in case of hit or miss.
        /// </summary>
        private void FireMissle(Label boardPosition)
        {
            boardPosition.Click -= BoardPosition_Click; // Event handlers unsubscribed to prevent un-needed method call
            boardPosition.Click -= BoardPositionFrontend_Click;
            int[] positionCoordinates = GetLabelCoordinates(boardPosition);
            FireOnCoordinates(positionCoordinates);
        }

        /// <summary>
        /// Proceeds to fire missle on the given coordinates,
        /// updating game state and board accordingly for hit/miss.
        /// </summary>
        public void FireOnCoordinates(int[] positionCoordinates)
        {
            BS.CheckForHit(positionCoordinates, this);
            UpdateBoardPosition(positionCoordinates);
        }

        /// <summary>
        /// Visually updates a board position based on the given coordinates.
        /// </summary>
        /// <param name="coordinates">Label to update.</param>
        private void UpdateBoardPosition(int[] coordinates)
        {
            if (BS.board[coordinates[0] + 1, coordinates[1] + 1] == BS.BoardStatus.Hit)
            {
                BoardArray[coordinates[0], coordinates[1]].BackColor = Color.Red;
                ToolTips.SetToolTip(BoardArray[coordinates[0], coordinates[1]], $"You struck a ship here!");
                return;
            }

            BoardArray[coordinates[0], coordinates[1]].BackColor = Color.White;
            ToolTips.SetToolTip(BoardArray[coordinates[0], coordinates[1]], $"You missed here!");
        }


        /// <summary>
        /// Searches through board array, grabs the x and y (or rather y and x) coordinates of 
        /// the board position, returns as integer array.
        /// </summary>
        /// <param name="boardPosition">The label which needs coordinates.</param>
        /// <returns></returns>
        private int[] GetLabelCoordinates(Label boardPosition)
        {
            int[] coordinates = { 0, 0 };

            for (int i = 0; i < BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < BoardArray.GetLength(1); j++)
                {
                    if (BoardArray[i, j] == boardPosition)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        #endregion

        #endregion

        #region Game Cleanup

        /// <summary>
        /// If number of boats sunken is equal to number of boats, we have a winner.
        /// </summary>
        /// <returns>True if win was found.</returns>
        public bool CheckForWin()
        {
            if (CarrierHealth != 0 || BattleshipHealth != 0 ||
                SubmarineHealth != 0 || CruiserHealth != 0 ||
                DestroyerHealth != 0) { return false; }

            // If there was a win, track this score. Update average score.
            int score = (int)Difficulty * 1000 / MissilesFired;
            GameScores.Add(score);
            AverageScore = GameScores.Sum() / GameScores.Count;
            return true;
        }

        /// <summary>
        /// Resets health and board state, sets game happening to true, and randomizes board.
        /// </summary>
        public void Reset()
        {
            if (!GameHappening) { GameHappening = true; }
            MissilesFired = 0;
            SetBoatHealth();
            BS.ResetBoard(Difficulty);
            BS.RandomizeBoats();
        }

        #endregion
    }
}
#endregion