using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefabs;

    public float zRange = 10.0f;
    public float xSpawnPoint = -20.0f;
    public float zStartingSpawnPoint = -12.0f;

    public float blockSpacing = 1.0f;
    public float blockSize = 5.0f;

    public float startDelay = 2;
    public float spawnInterval = 2.25f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBlock", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBlock()
    {
        int emptySpace = Random.Range(0, 5);
        //Debug.Log(emptySpace);
        for(int i=0; i<5; i++)
        {
            if(i == emptySpace)
            {
                continue;
            }
            Vector3 spawnPos = new Vector3(xSpawnPoint, 1, zStartingSpawnPoint + ((blockSize + blockSpacing) * i));
            Instantiate(blockPrefabs, spawnPos, blockPrefabs.transform.rotation);
        }
        
        
    }
}
