using UnityEngine;
using System.Collections;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnMapAddressables : MonoBehaviour
{

    public AssetReference mapPrefabReference;
    public float spawnInterval = 2f;
    public float mapSpeed = 2f;
    public float mapDestroyTime = 10f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnMap();
            timeSinceLastSpawn = 0f;
        }
    }

    private async void SpawnMap()
    {
        Vector3 spawnPosition = new Vector3(0, 10, 2);

        AsyncOperationHandle<GameObject> mapLoadHandle = mapPrefabReference.InstantiateAsync(spawnPosition, Quaternion.identity, null);

        await mapLoadHandle.Task;

        GameObject newMap = mapLoadHandle.Result;

        newMap.GetComponent<Map>().speed = mapSpeed;
        Destroy(newMap, mapDestroyTime);
    }
}
