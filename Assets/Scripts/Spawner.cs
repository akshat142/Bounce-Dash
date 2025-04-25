using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject obstacles;
    public GameObject coins;
    public float spawnInterval = 2f;
    public float spawnRangeX = 2.5f;
    public float spawnOffsetY = 10f;

    private float lastSpawnY;

    public Transform player;

    void Update()
    {
        if (player.position.y + spawnOffsetY > lastSpawnY)
        {
            SpawnObjects();
            lastSpawnY += spawnInterval;
        }
    }

    void SpawnObjects()
    {
        // Randomly decide whether to spawn coin or obstacle.
        float xValue = Random.value;

        if (xValue > 0.5f)
        {
            SpawnOne(obstacles, new Vector3(0, -90, -90));
        }
        else
        {
            SpawnOne(coins, Vector3.zero);
        }
    }

    void SpawnOne(GameObject items, Vector3 position)
    {
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new(x, lastSpawnY, 0);

        //Spawning item which could be osbtacle or coin.
        Instantiate(items, spawnPos, Quaternion.Euler(position));
    }
}
