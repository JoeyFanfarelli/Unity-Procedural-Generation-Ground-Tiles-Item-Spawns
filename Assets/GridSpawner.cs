using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public GameObject[] groundTilesList;
    public int gridXLength;     //Number of tiles on the X axis
    public int gridZLength;     //Number of tiles on the Z axis
    public float gridTileOffset;   //How much space should there be between grid tiles?
    public Vector3 gridStartPoint = Vector3.zero;   //Where should the grid begin spawning?
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }


    //This function runs through every (x,z) combination of coordinates by using two loops (one to rotate through each x, and another to rotate through each z). Generates a random tile prefab, calculates where it should go (based on the x and z values in the loop), and then places it. 
    //Ultimately, this spawns a grid of randomly generated tiles
    void SpawnGrid()
    {
        for (int x = 0; x < gridXLength; x++)       //loop through all x coordinates
        {
            for (int z = 0; z< gridZLength; z++)    //loop through each z coordinate, for each x coordinate
            {
                int randomIndex = Random.Range(0, groundTilesList.Length);      //generate a random number that can be used as an index to select a tile from the tile array
                Vector3 spawnPos = new Vector3(x * gridTileOffset, 0, z * gridTileOffset) + gridStartPoint;     //calculate the position where the tile will spawn - based on the current X and Z in the loop.
                GameObject clone = Instantiate(groundTilesList[randomIndex], spawnPos, Quaternion.identity);    //actually create the tile, and place it at the right position
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
