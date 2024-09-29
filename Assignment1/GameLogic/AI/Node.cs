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
 * instantiated and added to the Branch list. A CurrentBoard is passed into each of these constructors
 * indicating the move that Node should get.
 * 
 * It will continue to recursively call the constructor until a win/loss/draw is reached.
 * If this end state is reached, the score of the node will be set to a 1 for win, 0 for draw, and -1 for loss.
 *
 * After the for of each node has completed, the previous node will have the current node's score
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
        public char[,] CurrentBoard { get; set; }
        public int[] MoveCoordinates { get; set; }
        public List<Node> Branches { get; set; }
        public Node PreviousNode { get; set; }
        public int Score { get; set; }
        private bool IsAITurn { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Sets the CurrentBoard up, as well as node tracking, and then recursively calls itself
        /// until all positions are exhausted.
        /// </summary>
        public Node(char[,] currentBoard, int[] moveCoordinates, Node previousNode, bool isAITurn)
        {
            // Score starts at 0 for every new node
            Score = 0;

            CurrentBoard = currentBoard;
            MoveCoordinates = moveCoordinates;
            PreviousNode = previousNode;
            IsAITurn = isAITurn;
            Branches = new List<Node>();
            SearchBoard();

            // This will only be called after every possible future board move is searched for a given node
            ReturnPoints();
        }
        #endregion

        #region Main Logic
        /// <summary>
        /// Instantiates a new node for every possible move in the board
        /// </summary>
        private void SearchBoard()
        {
            // Iterate through the board
            for (int i = 0; i < CurrentBoard.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentBoard.GetLength(1); j++)
                {
                    // If the move is available at this position and it is AI's turn, get a new board 
                    // and instantiate a new Node into the branches list with that new state.
                    if (CurrentBoard[i, j] == '#' && IsAITurn)
                    {
                        int[] moveCoordinates = new int[] { i, j };
                        char[,] nextMoveBoard = GameState.UpdateBoard(CurrentBoard, moveCoordinates, 'O');
                        Branches.Add(new Node(nextMoveBoard, moveCoordinates, this, false));
                    }

                    // If the move is available at this position and it is the human's turn, get a new board 
                    // and instantiate a new Node into the branches list with that new state.
                    else if (CurrentBoard[i, j] == '#')
                    {
                        int[] moveCoordinates = new int[] { i, j };
                        char[,] nextMoveBoard = GameState.UpdateBoard(CurrentBoard, moveCoordinates, 'X');
                        Branches.Add(new Node(nextMoveBoard, moveCoordinates, this, true));
                    }
                }
            }
        }

        /// <summary>
        /// First checks for a win/loss/draw states and updates score based on that.
        /// </summary>
        private void ReturnPoints()
        {
            // If the previous node is null, instantly return, as it is the first node
            if (PreviousNode == null) { return; }

            // Check if there was a win - It would be for the previous player who
            // got to the end state board
            if (GameState.GetBoardState(CurrentBoard) == BoardState.Win && !IsAITurn) { Score = 1; }

            // Check if there was a loss - It would be for the current player who
            // had no moves available in the end state
            else if (GameState.GetBoardState(CurrentBoard) == BoardState.Win && IsAITurn) { Score = -10; }

            // A draw does not need to be checked, as node Score is at 0 by default.
            // Simply hand this nodes score to the previous node if it exists.
            PreviousNode.Score += Score;
        }
        #endregion
    }
    #endregion  
}
#endregion
