using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] itemsToSpawn;   //This array holds references to all the prefabs that will be within the pool of possible spawning options
    [SerializeField]
    public float negSpawnSpreadX, posSpawnSpreadX, negSpawnSpreadZ, posSpawnSpreadZ;  //The spread of possible coordinates where each item could spawn.
    [SerializeField]
    public float numSpawns;             //The number of spawns this script will generate.


    void Start()
    {
        for (int i = 0; i < numSpawns; i++) //Call the Spawn() function multiple times, based on the value of the numSpawns variable
        {
            Spawn();
        }
    }
         
    //Generate random index to select a random item to spawn, generate random position and rotation, and instantiate the object.
    void Spawn()
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Length); 
        Vector3 randomPos = new Vector3(Random.Range(negSpawnSpreadX, posSpawnSpreadX), 0, Random.Range(negSpawnSpreadZ, posSpawnSpreadZ)) + transform.position; 
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);   


        GameObject clone = Instantiate(itemsToSpawn[randomIndex], randomPos, randomRotation); 
    }


}
