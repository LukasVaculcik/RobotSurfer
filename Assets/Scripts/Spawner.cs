using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    public float spawnTime = 2f;
    public float speed = 10f;
    private float timeUntilSpawn;

    private void Update()
    {
        if (GameManager.Instance.isPlaying) {
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
        obstaclePosition.y = Random.Range(transform.position.y, 4);
        GameObject spawnedInstance = Instantiate(obstacleToSpawn, obstaclePosition, Quaternion.identity);
        Rigidbody2D obstacleRigidBody = spawnedInstance.GetComponent<Rigidbody2D>();
        obstacleRigidBody.velocity = Vector2.left * speed;
    }
}
