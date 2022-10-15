using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using Quaternion = UnityEngine.Quaternion;


public class GameGrid : MonoBehaviour
{
    public int width, height;
    public Tile[,] grid;

    public GameObject debug_tile;
    public GameObject debug_player;
    public Vector2Int debug_start;
    public Vector2Int debug_end;
    public Vector2Int player_position;

    void Start()
    {
        grid = new Tile[width, height];
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                grid[i, j] = new Tile(Tile.TileType.Plain);
                Instantiate(debug_tile, new UnityEngine.Vector3(i, j, 10), Quaternion.identity);
            }
        }

        debug_player = Instantiate(debug_player, new Vector3(debug_start.x, debug_start.y, 0), Quaternion.identity);
        player_position = debug_start;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Vector2Int next_step;
            if(Pathfind(player_position, debug_end, out next_step))
            {
                debug_player.transform.position = new Vector3(next_step.x, next_step.y, 0);
                player_position = next_step;
            }
        }
    }

    public bool Pathfind(Vector2Int start, Vector2Int end, out Vector2Int next_step)
    {
        Priority_Queue.IPriorityQueue<Vector2Int, float> pq = new SimplePriorityQueue<Vector2Int>();
        Dictionary<Vector2Int, Vector2Int> source = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, float> cost_so_far = new Dictionary<Vector2Int, float>();
        cost_so_far.Add(start, 0);
        
        pq.Enqueue(start, 0);

        bool found = false;

        while(pq.Count != 0)
        {
            Vector2Int current = pq.Dequeue();
            if(current == end)
            {
                found = true;
                break;
            }

            for(int x = current.x-1; x <= current.x+1; x++)
            {
                for(int y = current.y-1; y <= current.y+1; y++)
                {
                    Vector2Int next = new Vector2Int(x, y);
                    if(next == current)
                    {
                        continue;
                    }

                    if(next.x < 0 || next.y < 0 || next.x >= width || next.y >= height)
                    {
                        continue;
                    }

                    float new_cost = cost_so_far[current] + grid[next.x, next.y].GetCost();
                    if(x-current.x != 0 && y-current.y != 0)
                    {
                        new_cost += 0.001f;
                    }
                    if(!cost_so_far.ContainsKey(next) || new_cost < cost_so_far[next])
                    {
                        cost_so_far[next] = new_cost;
                        float priority = new_cost + Mathf.Max(
                            Mathf.Abs(end.x - next.x), Mathf.Abs(end.y - next.y));
                        Debug.Log(priority);
                        pq.Enqueue(next, priority);
                        source[next] = current;
                    }
                }
            }
        }

        if(!found)
        {
            next_step = Vector2Int.zero;
            return false;
        }

        Vector2Int backtrackStep = end;
        if(backtrackStep == start)
        {
            next_step = end;
            return true;
        }
        while(source[backtrackStep] != start)
        {
            backtrackStep = source[backtrackStep];
        }

        next_step = backtrackStep;
        return true;
    }
}

public class Tile
{
    public static Dictionary<TileType, int> cost;
    
    public TileType tile_type = TileType.Plain;
    public bool destroyed = false;

    public Tile(TileType t)
    {
        tile_type = t;
    }

    public int GetCost()
    {
        return 1;
        return cost[tile_type];
    }

    public enum TileType
    {
        Plain = 0,
        City = 1,
    }
}
