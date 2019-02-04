using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Player1: Red
    // Player2: Blue
    // 1 = Player1, 2 = Player2

    public GridNode[,] grid;
    public int gridSize;

    // Player 1 Attributes
    public int player1X = 4;
    public int player1Y = 0;
    int player1Movement = 2;
    int player1Attack = 2;
    int player1Health = 5;

    public int player2X = 5;
    public int player2Y = 9;
    int player2Movement = 2;
    int player2Attack = 2;
    int player2Health = 5;

    // Constructors
    public Grid() {
        grid = new GridNode[10, 10];
        gridSize = 10;
    }

    public Grid(int[,] terrainMap, int player1X, int player1Y, int player2X, int player2Y) {
        grid = new GridNode[10, 10];
        gridSize = 10;

        this.player1X = player1X;
        this.player1Y = player1Y;
        this.player2X = player2X;
        this.player2Y = player2Y;

        for(int i = 0; i < gridSize; i++) {
            for(int j = 0; j < gridSize; j++) {

                grid[i, j] = new GridNode(i, j, terrainMap[i,j]);

                if(player1X == i && player1Y == j) {
                    grid[i, j].player1OnNode = true;
                }

                if(player2X == i && player2Y == j) {
                    grid[i, j].player2OnNode = true;
                }
            }
        }
    }

    // Member functions
    public GridNode getNode(int x, int y) {
        return grid[x, y];
    }

    // Function that gets called to determine if a move a player
    // chooses is a valid move or not. If it is, it returns true and
    // updates the state of the game.
    public bool canMove(int player, int x, int y) {
        bool validMovement = false;
        bool validTerrain = false;
        bool playerNotOnNode = false;
        GridNode targetNode = grid[x, y];

        // Check for Valid Movement
        if(player == (int)Players.Player1) {

            for(int i = 0; i < 4; i++) {
                validMovement = movementCheck(player1Movement, i, player1X, player1Y, targetNode);
                if (validMovement) { break; }
            }

        }
        else {

            for (int i = 0; i < 4; i++) {
                validMovement = movementCheck(player2Movement, i, player2X, player2Y, targetNode);
                if (validMovement) { break; }
            }
        }

        // Check for valid terrain
        if(targetNode.terrain != (int)Terrains.Lava &&
           targetNode.terrain != (int)Terrains.Mountains) {
            validTerrain = true;
        }

        // Check that a player is not on the targeted node
        playerNotOnNode = !targetNode.playerOnNode();

        // If everything is valid, the tank can move to that location.
        // Update the state of the game
        if (validMovement && validTerrain && playerNotOnNode) {

            // Update State
            if(player == (int)Players.Player1) {
                grid[player1X, player1Y].player1OnNode = false;
                targetNode.player1OnNode = true;
                player1X = targetNode.x;
                player1Y = targetNode.y;
            }
            else {
                grid[player2X, player2Y].player2OnNode = false;
                targetNode.player2OnNode = true;
                player2X = targetNode.x;
                player2Y = targetNode.y;
            }

            return true;
        }
        else {
            return false;
        }
    }

    // Check up, down, left, or right of the player's current position
    // j spaces up to their maximum movement and see if it matches the
    // place they are currently trying to move to
    //
    // This will be called up to 4 times so all 4 directions are checked
    private bool movementCheck(int movementAmount, int currentIteration,
                               int currentPlayerX, int currentPlayerY,
                               GridNode targetNode) {

        for (int i = 0; i < movementAmount; i++) {
            switch (currentIteration) {
                case 0:
                    if ((currentPlayerX + i) == targetNode.x && currentPlayerY == targetNode.y) {
                        return true;
                    }
                    break;
                case 1:
                    if ((currentPlayerX - i) == targetNode.x && currentPlayerY == targetNode.y) {
                        return true;
                    }
                    break;
                case 2:
                    if (currentPlayerX == targetNode.x && (currentPlayerY + i) == targetNode.y) {
                        return true;
                    }
                    break;
                case 3:
                    if (currentPlayerX == targetNode.x && (currentPlayerY - i) == targetNode.y) {
                        return true;
                    }
                    break;
            }
        }

        return false;
    }

    // TODO: Joshua Implement
    // Check if valid attack
    // If valid, decrement other player's health by player's attack value
    // Return true
    // Otherwise just return false
    public bool canAttack(int player, int x, int y) {
        return true;
    }
}

enum Players {
    Player1 = 1,
    Player2 = 2
}
