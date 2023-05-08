using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float spawnRange = 2f;
    public float obstacleSpeed = 2f;
    public float obstacleDestroyTime = 10f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObstacle()
    {
        float spawnY = Random.Range((spawnRange)/2, spawnRange);
        Vector3 spawnPos = new Vector3(transform.position.x, spawnY, transform.position.z);
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        newObstacle.GetComponent<Obstacles>().speed = obstacleSpeed;
        Destroy(newObstacle, obstacleDestroyTime);
    }
}
