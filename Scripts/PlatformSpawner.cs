using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;
    float platformSize;
    Vector3 platformLastPos;

    void Start()
    {
        platformLastPos = platform.transform.position;
        platformSize = platform.transform.localScale.x;

        for (int i = 0; i < 5; i++)
        {
            SpawnPlatformInZ();
        }

        for (int r = 0; r < 50; r++)
        {
            SpawnPlatformInX();
        }

    }
 
    public void SpawnPlatform()
    {
        InvokeRepeating("SpawnPlatformInX", 2f, 0.2f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatformInX");
        }
    }

    void SpawnPlatformInZ() 
    {

        int rand = Random.Range(0, 1);
        if (rand < 1)
        {
            SpawnZ();
        }
        else if (rand >= 1)
        {
            SpawnX();
        }
    }

    void SpawnPlatformInX() 
    {
        int rand = Random.Range(0, 2);
        if (rand < 1)
        {
            SpawnX();
        }
        else if (rand >= 1)
        {
            SpawnZ();
        }
    }

    void SpawnX() 
    {
        Vector3 pos = platformLastPos;
        pos.x += platformSize;
        platformLastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4); 
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 2, pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ() 
    {
        Vector3 pos = platformLastPos;
        pos.z += platformSize;
        platformLastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4); 
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 2, pos.z), diamond.transform.rotation);
        }
    }
}