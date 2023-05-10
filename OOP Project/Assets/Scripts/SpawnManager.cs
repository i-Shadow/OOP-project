using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] consumables;

    private float zSpawn = 45f;
    private float ySpawn = -0.2f;
    private float minXspawn = -9.3f;
    private float maxXspawn = 9f;

    private float spawnEnemyDelay = 1.5f;
    private float spawnEnemyRate = 1f;
    private float spawnConsumableDelay = 4f;
    private float spawnConsumableRate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.Instance.gameOver)
        {
            InvokeRepeating("SpawnEnemy", spawnEnemyDelay, spawnEnemyRate);
            InvokeRepeating("SpawnConsumable", spawnConsumableDelay, spawnConsumableRate);
        }
           
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        float xRandomSpawn = Random.Range(minXspawn, maxXspawn);
        Instantiate(enemies[randomEnemy], new Vector3(xRandomSpawn, ySpawn, zSpawn), enemies[randomEnemy].transform.rotation);
    }

    private void SpawnConsumable()
    {
        int randomConsumable = Random.Range(0, consumables.Length);
        float xRandomSpawn = Random.Range(minXspawn, maxXspawn);
        Instantiate(consumables[randomConsumable], new Vector3(xRandomSpawn, ySpawn, zSpawn), consumables[randomConsumable].transform.rotation);
    }
}
