using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{

    public Tile gridElement;

    public int size = 7;

    private Tile[,] grid = new Tile[7,7];


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<size; i++)
        {
            for (int j=0; j<size; i++)
            {
                grid[i,j] = new Tile(Tile.TileType.Plain);
                Vector3 pos = new Vector3();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTile(int x, int y)
    {

        int tileId = (int) grid[x, y].tile_type;

        if (tileId == -1)
        {
            return;
        }

        //tilemap.SetTile(new Vector3Int(x, y, 0), tileSet.tiles[tildId]);
    }
}
