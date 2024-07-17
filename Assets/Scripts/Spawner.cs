using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    public float spawnTimeMin = 1.5f;
    public float spawnTimeMax = 3f;
    public float speed = 10f;
    public bool randomizeSpawnPositionY = true;
    private float timeUntilSpawn;
    private float spawnTime;

    private void Update()
    {
        if (GameManager.Instance.isPlaying) {
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= spawnTime) {
            Spawn();
            timeUntilSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 obstaclePosition = transform.position;
        if (randomizeSpawnPositionY) {
            obstaclePosition.y = Random.Range(transform.position.y, 4);
        }
        GameObject spawnedInstance = Instantiate(obstacleToSpawn, obstaclePosition, Quaternion.identity);
        Rigidbody2D obstacleRigidBody = spawnedInstance.GetComponent<Rigidbody2D>();
        obstacleRigidBody.velocity = Vector2.left * speed;
    }
}
