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
        public int CarrierHealth { get; set; }
        public int BattleshipHealth { get; set; }
        public int SubmarineHealth { get; set; }
        public int CruiserHealth { get; set; }
        public int DestroyerHealth { get; set; }
        public bool GameHappening { get; set; }
        #endregion

        /// <summary>
        /// Simply insantiates game related field.
        /// </summary>
        public GameState()
        {
            CarrierHealth = BS.GetBoatSize(BS.Boats.Carrier);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Battleship);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Submarine);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Cruiser);
            CarrierHealth = BS.GetBoatSize(BS.Boats.Destroyer);
        }
    }
}
#endregion