﻿/*
 * Title: BS.GameLogic.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-06
 * Purpose: To represent all logic related to gameplay
 * for the battleship game.
 */

#region Namespaces used

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
    /// This partial class contains all logic related to gameplay for the battleship game.
    /// It will update progress, 
    /// </summary>
    public static partial class BS
    {
        #region Main Logic Methods

        /// <summary>
        /// Creates a 2d label array based on the provided difficulty.
        /// </summary>
        /// <returns>The 2d label representation of the board.</returns>
        public static Label[,] GetBoardAsLabelArray()
        {
            // Iterate through board size and add to the array
            Label[,] boardArray = new Label[MAX_BOARD_SIZE, MAX_BOARD_SIZE];
            for (int i = 0; i < MAX_BOARD_SIZE; i++)
            {
                for (int j = 0; j < MAX_BOARD_SIZE; j++)
                {
                    boardArray[i, j] = new Label();
                }

            }

            // Return the array after it's been built.
            return boardArray;
        }

        /// <summary>
        /// Searches through board array for a hit matching the coordinates provided.
        /// Updates game state so that progress is accurately kept.
        /// </summary>
        /// <param name="coordinates">The coordinates to check.</param>
        /// <param name="gameState">The gameState to update.</param>
        public static void CheckForHit(int[] coordinates, GameState gameState)
        {
            // Check if there was already a hit or a miss there
            if (board[coordinates[0] + 1, coordinates[1] + 1] == BoardStatus.Hit ||
                board[coordinates[0] + 1, coordinates[1] + 1] == BoardStatus.Miss)
            {
                return;
            }

            // Now check if any boat was hit and update game state and boardstatus
            if (boatPositions[coordinates[0] + 1, coordinates[1] + 1] == Boats.Destroyer)
            {
                gameState.DestroyerHealth--;
                TrackHit(coordinates, gameState);
                return;
            }
            if (boatPositions[coordinates[0] + 1, coordinates[1] + 1] == Boats.Submarine)
            {
                gameState.SubmarineHealth--;
                TrackHit(coordinates, gameState);
                return;
            }
            if (boatPositions[coordinates[0] + 1, coordinates[1] + 1] == Boats.Cruiser)
            {
                gameState.CruiserHealth--;
                TrackHit(coordinates, gameState);
                return;
            }
            if (boatPositions[coordinates[0] + 1, coordinates[1] + 1] == Boats.Battleship)
            {
                gameState.BattleshipHealth--;
                TrackHit(coordinates, gameState);
                return;
            }
            if (boatPositions[coordinates[0] + 1, coordinates[1] + 1] == Boats.Carrier)
            {
                gameState.CarrierHealth--;
                TrackHit(coordinates, gameState);
                return;
            }

            gameState.MissilesFired++;
            board[coordinates[0] + 1, coordinates[1] + 1] = BoardStatus.Miss;
        }

        /// <summary>
        /// Simply updates a game state and the static BS boardstatus array to indicate a hit.
        /// </summary>
        /// <param name="coordinates">Coordinates of the hit.</param>
        /// <param name="gameState">Gamestate to update.</param>
        private static void TrackHit(int[] coordinates, GameState gameState)
        {
            gameState.MissilesFired++;
            board[coordinates[0] + 1, coordinates[1] + 1] = BoardStatus.Hit;
        }

        /// <summary>
        /// Resets board status, so that every index is empty.
        /// </summary>
        /// <param name="difficulty">The difficulty to set the board to.</param>
        public static void ResetBoard(Difficulty difficulty)
        {
            // Set the size of the board based on the difficulty
            SetBoardSize(difficulty);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = BoardStatus.Empty;
                    boatPositions[i, j] = Boats.NoBoat;
                }
            }
        }

        /// <summary>
        /// Sets board size based on a difficulty's int value.
        /// </summary>
        /// <param name="difficulty">The difficulty to set the board to.</param>
        private static void SetBoardSize(Difficulty difficulty)
        {
            MAX_BOARD_SIZE = (int)difficulty;
            board = new BoardStatus[(int)difficulty + 1, (int)difficulty + 1];
            boatPositions = new Boats[(int)difficulty + 1, (int)difficulty + 1];
        }

        #endregion

    }
}

#endregion
