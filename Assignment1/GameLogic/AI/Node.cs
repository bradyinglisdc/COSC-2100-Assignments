/*
 * Title: Node.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-29
 * Purpose: This class contains the definition for a decision Node for the MiniMaxAI.
 * 
 * How this algorithm works:
 * Each node contains a list of Nodes called Branches. Each node within these Branches
 * has a property called PreviousNode, which allows easy tracking of decision branches,
 * as well as a property called AIturn, indicating if the move should be O (for AI), or X (for player).
 * 
 * The constructor is called, and these branches of nodes are defined. Next, a for loop is called 
 * to iterate through every possible board position. On each iteration of the loop, a new Node is
 * instantiated and added to the Branch list. A boardState is passed into each of these constructors
 * indicating the move that Node should get.
 * 
 * It will continue to recursively call the constructor until a win/loss/draw is reached.
 * If this end state is reached, the score of the node will be set to a 1 for win, 0 for draw, and -1 for loss.
 *
 * After the for of each node has completed, the previous node will have the current node's score added
 * to it, essentially sending the scoer from an end state all the way back to the beginning node.
 * 
 * The Node within the starting Node's branches with the highest score is then chosen.
*/

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace definition
namespace Assignment1
{
    #region Class Definition
    public class Node
    {
        #region Properties
        public char[,] BoardState { get; set; }
        public int[] MoveCoordinates { get; set; }
        public List<Node> Branches { get; set; }
        public Node PreviousNode { get; set; }
        public int Score { get; set; }
        private bool IsAITurn { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Sets the board state up, as well as node tracking, and then recursively calls itself
        /// until all positions are exhausted.
        /// </summary>
        public Node(char[,] boardState, int[] moveCoordinates, Node previousNode, bool isAITurn)
        {
            BoardState = boardState;
            MoveCoordinates = moveCoordinates;
            PreviousNode = previousNode;
            IsAITurn = isAITurn;
            Branches = new List<Node>();
            SearchBoard();

            // This will only be called after every possible future board state is searched for a given node
            ReturnPoints();
        }
        #endregion

        #region Main Logic
        /// <summary>
        /// Instantiates a new node for every possible move in the board state
        /// </summary>
        private void SearchBoard()
        {
            // Iterate through the board
            for (int i = 0; i < BoardState.GetLength(0); i++)
            {
                for (int j = 0; j < BoardState.GetLength(1); j++)
                {
                    // Check if a move is available at this position
                    if (BoardState[i,j] == '#' && IsAITurn) { Branches.Add(new Node())}


                }
            }


        }

        #endregion




    }
    #endregion  
}
#endregion
