using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] obstaclesPrefabs;
    public Transform[] spawnPoints;

    private int randomObstacle;
    private int randomSpawnpoint;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {

        if (timeBtwSpawns <= 0)
        {
            randomObstacle = Random.Range(0, obstaclesPrefabs.Length);
            randomSpawnpoint = Random.Range(0, spawnPoints.Length);
            Instantiate(obstaclesPrefabs[randomObstacle], spawnPoints[randomSpawnpoint].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}
