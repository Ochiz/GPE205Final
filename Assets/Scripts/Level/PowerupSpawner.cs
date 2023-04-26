using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    private GameObject spawnedPickup;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedPickup == null)
        {          
            if (Time.time > nextSpawnTime)
            {
                if (GameManager.instance != null)
                {
                    if (GameManager.instance.level.totalPowerups < GameManager.instance.level.maxPowerups)
                    {
                        spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                        nextSpawnTime = Time.time + spawnDelay;
                        GameManager.instance.level.totalPowerups += 1;
                    }
                }
            }
        }
        else
        {            
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
