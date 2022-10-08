using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Dictionary<Tile.TileType, int> pathfindingCosts;
    public int width, height;
    public Tile[,] grid;

    void Start()
    {
        grid = new Tile[width, height];
    }
}

public class Tile
{
    public static Dictionary<TileType, int> cost;
    
    public TileType tile_type = TileType.Plain;
    public bool destroyed = false;

    public Tile()
    {
        destroyed = false;
        tile_type = TileType.Plain;
    }

    public int GetCost()
    {
        return cost[tile_type];
    }

    public enum TileType
    {
        Plain = 0,
        City = 1,
    }
}
