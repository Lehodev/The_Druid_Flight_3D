using UnityEngine;
using System.Collections;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObstaclesAddressables : MonoBehaviour
{

    public AssetReference obstaclePrefabReference;
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

    private async void SpawnObstacle()
    {
        float spawnY = Random.Range(spawnRange, spawnRange * 2);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);

        AsyncOperationHandle<GameObject> obstacleLoadHandle = obstaclePrefabReference.InstantiateAsync(spawnPosition, Quaternion.identity, null);

        await obstacleLoadHandle.Task;

        GameObject newObstacle = obstacleLoadHandle.Result;

        newObstacle.GetComponent<Obstacles>().speed = obstacleSpeed;
        Destroy(newObstacle, obstacleDestroyTime);
    }
}
