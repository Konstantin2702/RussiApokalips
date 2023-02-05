using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    public Camera camera;

    public Transform grid;

    private float defaultHeight;

    private float defaultWidth;
    
    public Vector2 zeroPosition;

    private int tileSize = 33;

    private bool generate;
    
    private Vector2 correction = new Vector2(-8f, 2.5f);

    private GameObject[] tiles;

    public GameObject startTile;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        tiles = Resources.LoadAll<GameObject>("Tiles");
        //GameObject child = grid.gameObject.transform.Find("tile_1").gameObject;
        correction = startTile.transform.position;
        //Debug.Log(correction);
        zeroPosition = (Vector2)camera.transform.position + correction;
        defaultHeight = camera.orthographicSize;
        defaultWidth = camera.orthographicSize * camera.aspect;
        
        generate = true;
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
        
        if(camera.transform.position.x + correction.x > zeroPosition.x + defaultHeight - 1)
        {
            if (generate) 
            {
                zeroPosition.x += tileSize;
                GameObject newTile = Instantiate(tiles[rnd.Next(0, tiles.Length - 1)], 
                    zeroPosition, Quaternion.identity) as GameObject;
                newTile.transform.SetParent(grid);
                generate = false;
            }
        }
        if(camera.transform.position.y + correction.y > zeroPosition.y + defaultWidth - 1)
        {
            if(generate)
            {
                zeroPosition.y += tileSize;
                GameObject newTile = Instantiate(tiles[rnd.Next(0, tiles.Length - 1)], 
                    zeroPosition, Quaternion.identity) as GameObject;
                newTile.transform.SetParent(grid);
                generate = false;
            }
            
        }
    }
}
