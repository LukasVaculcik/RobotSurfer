using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    public int amountToSpawn = 1;
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
        GameObject entityToSpawn = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 entityPosition = transform.position;
        if (randomizeSpawnPositionY) {
                entityPosition.y = Random.Range(transform.position.y, 4);
            }
        for (int i = 1; i < amountToSpawn + 1; i++)
        {
            entityPosition.x = transform.position.x + (1 * i);
            GameObject spawnedInstance = Instantiate(entityToSpawn, entityPosition, Quaternion.identity);
            Rigidbody2D entityRigidBody = spawnedInstance.GetComponent<Rigidbody2D>();
            entityRigidBody.velocity = Vector2.left * speed;
        }
    }
}
