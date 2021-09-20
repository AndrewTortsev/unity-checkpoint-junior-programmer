using RunnerApi;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour, Spawner
{
    public GameObject obstacle;
    public float minSpawnPeriod = 1f;
    public float maxSpawnPeriod = 2f;
    private delegate void SpawnTask();
    private SpawnTask spawnTask;
    

    void Start()
    {
        spawnTask = SpawnCoroutine;
        InvokeRepeating(spawnTask.Method.Name, 0f, GetRandomPeriod());
    }

    void Update()
    {
        if (GameManager.INSTANCE.IsGameOver)
        {
            CancelInvoke(spawnTask.Method.Name);
        }
    }

    public void Spawn()
    {
        Instantiate(obstacle, this.transform.position, obstacle.transform.rotation);
    }

    private void SpawnCoroutine()
    {
        StartCoroutine(SpawnByDelay());
    }

    private IEnumerator SpawnByDelay()
    {
        yield return new WaitForSeconds(GetRandomPeriod());
        Spawn();
    }

    private float GetRandomPeriod()
    {
        return Random.Range(minSpawnPeriod, maxSpawnPeriod);
    }
}
