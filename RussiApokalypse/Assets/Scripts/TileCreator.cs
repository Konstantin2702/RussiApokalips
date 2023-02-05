using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileCreator : MonoBehaviour
{
    public Camera camera;

    public Transform grid;

    private float defaultHeight;

    private float defaultWidth;
    
    public Vector2 zeroPosition;

    private int tileSize = 33;

    private bool generate;
    
    private Vector2 correction;

    private int orientation;

    private GameObject[] tiles;

    //public GameObject startTile;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        tiles = Resources.LoadAll<GameObject>("Start_finish");
        orientation = rnd.Next(0, 1);
        zeroPosition = (Vector2)camera.transform.position;
        //GameObject start = grid.gameObject.transform.Find("tile_1").gameObject;
        GameObject start = tiles.First(obj => obj.tag == "Start");
        GameObject startTile = Instantiate(start, zeroPosition, 
            Quaternion.Euler(0f, 0f, orientation * 90f)) as GameObject;
        startTile.transform.SetParent(grid);

        correction = startTile.transform.position;
        Debug.Log(correction);
        zeroPosition += correction;
        defaultHeight = camera.orthographicSize;
        defaultWidth = camera.orthographicSize * camera.aspect;
        generate = true;
        tiles = Resources.LoadAll<GameObject>("Tiles");
    }

    // Update is called once per frame
    void Update()
    {
        if (!generate)
        {
            if (Mathf.Abs(camera.transform.position.x - zeroPosition.x) >= tileSize / 2)
            {
                if(camera.transform.position.x > zeroPosition.x)
                {
                    zeroPosition.x += tileSize;
                }
                // else
                // {
                //     zeroPosition.x -= tileSize;
                // }
                generate = true;
            }
            if (Mathf.Abs(camera.transform.position.y - zeroPosition.y) >= tileSize / 2)
            {
                if(camera.transform.position.y > zeroPosition.y)
                {
                    zeroPosition.y += tileSize;
                }
                // else
                // {
                //     zeroPosition.y -= tileSize;
                // }
                generate = true;
            }
        }
        
        if(camera.transform.position.x > zeroPosition.x + defaultWidth)
        {
            if (generate) 
            {
                zeroPosition.x += tileSize;
                GameObject newTile = Instantiate(tiles[rnd.Next(0, tiles.Length - 1)], 
                    zeroPosition, Quaternion.Euler(0f, 0f, orientation * 90f)) as GameObject;
                newTile.transform.SetParent(grid);
                generate = false;
            }
        }
        if(camera.transform.position.y > zeroPosition.y + defaultHeight)
        {
            if(generate)
            {
                zeroPosition.y += tileSize;
                Quaternion rot = Quaternion.Euler(0, transform.eulerAngles.y + 45, 0);
                GameObject newTile = Instantiate(tiles[rnd.Next(0, tiles.Length - 1)], 
                    zeroPosition, Quaternion.Euler(0f, 0f, orientation * 90f)) as GameObject;
                newTile.transform.SetParent(grid);
                generate = false;
            }
            
        }
    }
}
