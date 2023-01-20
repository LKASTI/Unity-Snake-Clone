using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 9;
    private int cols = 9;
    private float tileSize;
    public GameObject tileRef;
    private GameObject tile;

    void Start()
    {
        for(int y = 1; y <= rows; y++)
        {
            for(int x = 1; x <= cols; x++)
            {
                tile = Instantiate(tileRef, transform);
                tile.transform.position = new Vector3(x,y,0);
            }
        }
    }

}
