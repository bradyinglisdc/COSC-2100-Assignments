/*
 * Title: GameState.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-06
 * Purpose: To capture variables related to a battleship game instance.
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
        #endregion

        /// <summary>
        /// Simply insantiates game related field.
        /// </summary>
        public GameState()
        {
            SetBoatHealth();
            BoardArray = BS.GetBoardAsLabelArray(Difficulty.Easy);
            Difficulty = Difficulty.Easy;
            MissilesFired = 0;
        }

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

        /// <summary>
        /// If number of boats sunken is equal to number of boats, we have a winner.
        /// </summary>
        /// <returns>True if win was found.</returns>
        public bool CheckForWin()
        {
            if (CarrierHealth != 0 || BattleshipHealth != 0 ||
                SubmarineHealth != 0 || CruiserHealth != 0 ||
                DestroyerHealth != 0) { return false; }
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
            BS.ResetBoard();
            BS.RandomizeBoats();
        }
    }
}
#endregion