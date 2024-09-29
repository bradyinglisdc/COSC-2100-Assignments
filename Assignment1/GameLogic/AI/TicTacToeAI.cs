/*
 * Title: TicTacToeAI.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-25
 * Purpose: This static class contains the definition for the decision making process of the MiniMax
 * algorithm AI.
 * 
 * It simply instantiates a new Node using the starting board state. This Node recursively calls
 * it's constructor for each possible position in the board.  Within a node end, score of 1 is 
 * assigned if the AI wins, a score of 0 is assigned if the AI draws, and a score of -1 is assigned 
 * if the AI loses. This score is then passed to the previous node, to tally up at the first decision
 * branch. This class simply picks the highest score move within the node's branch list.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace Definition
namespace Assignment1
{
    #region Class Definition
    public static class TicTacToeAI
    {
        /// <summary>
        /// Searches through gamestate to find the best move
        /// </summary>
        /// <param name="boardState">The boardstate to search.</param>
        /// <returns>Coordinates of the AI calculated best move.</returns>
        public static int[] FindBestMove(char[,] boardState, bool IsAITurn)
        {
            // Simply instantiate a node and return the best move in the decision branch.
            // Since this is the starting node, it's move coordinates and previous node will be null.
            Node startingNode = new Node(boardState, null, null, IsAITurn);

            Node bestNextMove = null;
            foreach (Node node in startingNode.Branches)
            {
                if (bestNextMove == null || node.Score > bestNextMove.Score) { bestNextMove = node; }
            }
            return bestNextMove.MoveCoordinates;
        }
    }
    #endregion
}
#endregion
