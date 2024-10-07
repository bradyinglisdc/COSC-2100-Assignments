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
        #endregion

        /// <summary>
        /// Simply insantiates game related field.
        /// </summary>
        public GameState()
        {
            SetBoatHealth();
            BoardArray = BS.GetBoardAsLabelArray(Difficulty.Easy);
            Difficulty = Difficulty.Easy; 
        }

        /// <summary>
        /// Sets health of all boats back to full.
        /// </summary>
        private void SetBoatHealth()
        {
            CarrierHealth = BS.GetBoatSize(BS.Boats.Carrier);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Battleship);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Submarine);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Cruiser);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Destroyer);
        }

        /// <summary>
        /// Resets health and board state, sets game happening to true, and randomizes board.
        /// </summary>
        public void Reset()
        {
            if (!GameHappening) { GameHappening = true; }
            SetBoatHealth();
            BS.ResetBoard();
            BS.RandomizeBoats();
        }
    }
}
#endregion