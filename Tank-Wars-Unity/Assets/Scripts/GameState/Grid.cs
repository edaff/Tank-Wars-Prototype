﻿using System.Collections;
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
    int player1PowerupDuration = 0;

    public int player2X = 5;
    public int player2Y = 9;
    int player2Movement = 2;
    int player2Attack = 2;
    int player2Health = 5;
    int player2PowerupDuration = 0;

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

        int mappedX = 0;
        int mappedY = gridSize - 1;

        for(int i = 0; i < gridSize; i++) {
            mappedY = gridSize - 1;
            for(int j = 0; j < gridSize; j++) {

                grid[i, j] = new GridNode(i, j, terrainMap[mappedY,mappedX]);

                if(player1X == i && player1Y == j) {
                    grid[i, j].player1OnNode = true;
                }

                if(player2X == i && player2Y == j) {
                    grid[i, j].player2OnNode = true;
                }

                mappedY--;
            }
            mappedX++;
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
        if(targetNode.terrain != (int)Terrains.Mountains) {
            validTerrain = true;
        }

        if(targetNode.terrain == (int)Terrains.Lava){
            if(player == (int)Players.Player1) {
                player1Health = 0;
            }
            else{
                player2Health = 0;
            }
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

            Debug.Log("Player " + player + " moves to Position: " + targetNode.x + "," + targetNode.y + " - Terrain: " + (Terrains)targetNode.terrain);

            return true;
        }
        else {

            Debug.Log("Invalid Move! " + " - Valid Movement: " 
                      + validMovement + " - Valid Terrain: "
                      + validTerrain + " - Player Not On Node: " 
                      + playerNotOnNode);

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

        for (int i = 1; i <= movementAmount; i++) {
            switch (currentIteration) {
                case 0:
                    // Index out of bounds check
                    if ((currentPlayerX + i) >= gridSize) { continue; }

                    if(grid[currentPlayerX + i, currentPlayerY].terrain == (int)Terrains.Mountains) { return false; }

                    // Tile check
                    if ((currentPlayerX + i) == targetNode.x && currentPlayerY == targetNode.y) {
                        return true;
                    }
                    break;
                case 1:
                    // Index out of bounds check
                    if ((currentPlayerX - i) < 0) { continue; }

                    if (grid[currentPlayerX - i, currentPlayerY].terrain == (int)Terrains.Mountains) { return false; }

                    // Tile check
                    if ((currentPlayerX - i) == targetNode.x && currentPlayerY == targetNode.y) {
                        return true;
                    }
                    break;
                case 2:
                    // Index out of bounds check
                    if ((currentPlayerY + i) >= gridSize) { continue; }

                    if (grid[currentPlayerX, currentPlayerY + i].terrain == (int)Terrains.Mountains) { return false; }

                    // Tile check
                    if (currentPlayerX == targetNode.x && (currentPlayerY + i) == targetNode.y) {
                        return true;
                    }
                    break;
                case 3:
                    // Index out of bounds check
                    if ((currentPlayerY - i) < 0) { continue; }

                    if (grid[currentPlayerX, currentPlayerY - i].terrain == (int)Terrains.Mountains) { return false; }

                    // Tile check
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

        bool validAttack = false;
        bool validTerrain = false;
        GridNode targetNode = grid[x, y];

        if(player == (int)Players.Player1)
        {
            for(int i = 0; i < 4; i++)
            {
                validAttack = movementCheck(player1Attack, i, player1X, player1Y, targetNode);
                if (validAttack) { break; }
            }
        }
        else
        {
            for(int i = 0; i < 4; i++)
            {
                validAttack = movementCheck(player2Attack, i, player2X, player2Y, targetNode);
                if (validAttack) { break; }
            }
        }

        if (validAttack) {
            if (player == (int)Players.Player1) {
                Debug.Log("Player 1 hits Player 2 for " + player1Attack + " damage! Player 2 health is now at " + (player2Health - player1Attack));

                player2Health -= player1Attack;
            }
            else if (player == (int)Players.Player2) {
                Debug.Log("Player 2 hits Player 1 for " + player2Attack + " damage! Player 1 health is now at: " + (player1Health - player2Attack));

                player1Health -= player2Attack;
            }
            else {
                Debug.Log("No player was hit...");

                updatePowerupState(player);

                return false;
            }

            updatePowerupState(player);

            return true;
        }
        else {
            updatePowerupState(player);

            return false;
        }
    }

    private void updatePowerupState(int player) {
        if (player == (int)Players.Player1 && player1PowerupDuration >= 0) {
            player1PowerupDuration--;

            if(player1PowerupDuration == 0) {
                player1Attack--;
            }
        }

        if(player == (int)Players.Player2 && player2PowerupDuration >= 0) {
            player2PowerupDuration--;

            if(player2PowerupDuration == 0) {
                player2Attack--;
            }
        }
    }

    public string gamble(int player) {
        System.Random randomNumberGenerator = new System.Random();
        int gamble = randomNumberGenerator.Next(1,5);

        // Decrement the health of the player who gambled
        if(player == (int)Players.Player1) {
            player1Health--;
        }
        else {
            player2Health--;
        }

        // Return correct powerup based on the roll
        switch(gamble) {
            case 1:
                if(player == (int)Players.Player1) {
                    player1PowerupDuration = 1;
                    player1Attack++;
                }
                else {
                    player2PowerupDuration = 1;
                    player2Attack++;
                }

                if(player == (int)Players.Player1) {
                    Debug.Log("Player 1 rolled for a Damage Boost! Attack is now: " + player1Attack);
                }
                else {
                    Debug.Log("Player 2 rolled for a Damage Boost! Attack is now: " + player2Attack);
                }
                

                return "Damage Boost";

            default:

                Debug.Log("Player " + player + " rolled for a Nothing! No powerup is obtained...");

                return "Nothing! :(";
        }
    }

    public int getPlayerHealth(int player) {
        if(player == (int)Players.Player1) {
            return player1Health;
        }
        else {
            return player2Health;
        }
    }

    public void setPlayerHealth(int player, int newHealth) {
        if(player == (int)Players.Player1) {
            player1Health = newHealth;
        }
        else {
            player2Health = newHealth;
        }
    }

    public int getPlayerAttack(int player) {
        if (player == (int)Players.Player1) {
            return player1Attack;
        }
        else {
            return player2Attack;
        }
    }

    public int getPlayerMovement(int player) {
        if (player == (int)Players.Player1) {
            return player1Movement;
        }
        else {
            return player2Movement;
        }
    }

    public int getPlayerPowerupDuration(int player) {
        if (player == (int)Players.Player1) {
            return player1PowerupDuration;
        }
        else {
            return player2PowerupDuration;
        }
    }

    public bool isPlayer1Dead() {
        if (player1Health <= 0) {
            return true;
        }

        return false;
    }

    public bool isPlayer2Dead() {
        if (player2Health <= 0) {
            return true;
        }

        return false;
    }

    public ArrayList getAllValidMovementTiles(int player) {
        ArrayList validMovementCoordinates = new ArrayList();
        int movementAmount, currentPlayerX, currentPlayerY;

        if(player == (int)Players.Player1) {
            movementAmount = player1Movement;
            currentPlayerX = player1X;
            currentPlayerY = player1Y;
        }
        else {
            movementAmount = player2Movement;
            currentPlayerX = player2X;
            currentPlayerY = player2Y;
        }

        bool pathBlocked = false;
        for (int currentIteration = 0; currentIteration < 4; currentIteration++) {
            pathBlocked = false;
            for (int i = 1; i <= movementAmount; i++) {
                switch (currentIteration) {
                    case 0:
                        // Index out of bounds check
                        if ((currentPlayerX + i) >= gridSize) { continue; }

                        if (grid[currentPlayerX + i, currentPlayerY].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validMovementCoordinates.Add(new Coord(currentPlayerX + i, currentPlayerY));
                        }

                        break;
                    case 1:
                        // Index out of bounds check
                        if ((currentPlayerX - i) < 0) { continue; }

                        if (grid[currentPlayerX - i, currentPlayerY].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validMovementCoordinates.Add(new Coord(currentPlayerX - i, currentPlayerY));
                        }

                        break;
                    case 2:
                        // Index out of bounds check
                        if ((currentPlayerY + i) >= gridSize) { continue; }

                        if (grid[currentPlayerX, currentPlayerY + i].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validMovementCoordinates.Add(new Coord(currentPlayerX, currentPlayerY + i));
                        }

                        break;
                    case 3:
                        // Index out of bounds check
                        if ((currentPlayerY - i) < 0) { continue; }

                        if (grid[currentPlayerX, currentPlayerY - i].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validMovementCoordinates.Add(new Coord(currentPlayerX, currentPlayerY - i));
                        }

                        break;

                }
            }
        }

        return validMovementCoordinates;
    }

    public ArrayList getAllValidAttackTiles(int player) {
        ArrayList validAttackCoordinates = new ArrayList();
        int attackAmount, currentPlayerX, currentPlayerY;

        if (player == (int)Players.Player1) {
            attackAmount = player1Attack;
            currentPlayerX = player1X;
            currentPlayerY = player1Y;
        }
        else {
            attackAmount = player2Attack;
            currentPlayerX = player2X;
            currentPlayerY = player2Y;
        }

        bool pathBlocked = false;
        for (int currentIteration = 0; currentIteration < 4; currentIteration++) {
            pathBlocked = false;
            for (int i = 1; i <= attackAmount; i++) {
                switch (currentIteration) {
                    case 0:
                        // Index out of bounds check
                        if ((currentPlayerX + i) >= gridSize) { continue; }

                        if (grid[currentPlayerX + i, currentPlayerY].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validAttackCoordinates.Add(new Coord(currentPlayerX + i, currentPlayerY));
                        }

                        break;
                    case 1:
                        // Index out of bounds check
                        if ((currentPlayerX - i) < 0) { continue; }

                        if (grid[currentPlayerX - i, currentPlayerY].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validAttackCoordinates.Add(new Coord(currentPlayerX - i, currentPlayerY));
                        }

                        break;
                    case 2:
                        // Index out of bounds check
                        if ((currentPlayerY + i) >= gridSize) { continue; }

                        if (grid[currentPlayerX, currentPlayerY + i].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validAttackCoordinates.Add(new Coord(currentPlayerX, currentPlayerY + i));
                        }

                        break;
                    case 3:
                        // Index out of bounds check
                        if ((currentPlayerY - i) < 0) { continue; }

                        if (grid[currentPlayerX, currentPlayerY - i].terrain == (int)Terrains.Mountains) {
                            pathBlocked = true;
                            continue;
                        }

                        if (!pathBlocked) {
                            validAttackCoordinates.Add(new Coord(currentPlayerX, currentPlayerY - i));
                        }

                        break;

                }
            }
        }

        return validAttackCoordinates;
    }

    // Check if either player is out of health, if so
    // return 1 for player 1 or 2 for player 2. If nobody,
    // has won the game, return 0.
    public int isGameOver() {
        if (player1Health <= 0) {
            return 1;
        }
        else if (player2Health <= 0) {
            return 2;
        }
        else {
            return 0;
        }
    }
}

public struct Coord {
    public int x;
    public int y;

    public Coord(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return this.x;
    }

    public int getY() {
        return this.y;
    }
}

enum Players {
    Player1 = 1,
    Player2 = 2
}