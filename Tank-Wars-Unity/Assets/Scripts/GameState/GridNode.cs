using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour
{
    public bool player1OnNode;
    public bool player2OnNode;
    public int x;
    public int y;
    public int terrain;

    public GridNode(int x, int y, int terrain) {
        this.x = x;
        this.y = y;
        this.terrain = terrain;
        player1OnNode = false;
        player2OnNode = false;
    }
}

enum Terrains {
    Desert = 0,
    Forest = 1,
    Water = 2,
    Lava = 3,
    Mountains = 4
}