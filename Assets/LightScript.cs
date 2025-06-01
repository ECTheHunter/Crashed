using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject itemToSpawn;     // Prefab to spawn
    public float minSpawnTime = 15f;    // Minimum time between spawns
    public float maxSpawnTime = 60f;    // Maximum time between spawns

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnItem();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnItem()
    {

        // Choose a random spawn point
        

        // Spawn the item
        Instantiate(itemToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
}
