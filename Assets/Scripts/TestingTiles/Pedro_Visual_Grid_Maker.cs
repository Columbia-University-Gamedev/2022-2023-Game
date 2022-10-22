using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedro_Visual_Grid_Maker : MonoBehaviour
{
    public Tile gridElement;

    public int size = 7;

    private Tile[,] grid = new Tile[7, 7];

    [SerializeField] GameObject square;


    // Start is called before the first frame update
    void Start()
    {

        SpriteRenderer sprite = square.GetComponent<SpriteRenderer>();

        float length = sprite.bounds.extents.y * 2;
        float width = sprite.bounds.extents.x * 2;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = new Tile(Tile.TileType.Plain);
            }
        }


        //Make Grid
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject newSquare = Instantiate(square, new Vector3(i * length, j * width, 0), Quaternion.identity);
                SpriteRenderer newSprite = newSquare.GetComponent<SpriteRenderer>();
                
                if(j % 2 == 0 && i % 2 == 0)
                {
                    sprite.color = new Color(1,0,0);
                }
                
                else if(j%2 == 0)
                {
                    sprite.color = new Color(0, 0, 1);
                }
                else if(i % 3 == 0)
                {
                    sprite.color = new Color(0, 1, 0);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
