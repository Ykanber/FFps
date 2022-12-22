using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    float time = 0;


    int wave = 1;
    float spawnTime = 0;

    GameObject[] prefabs;
    int[] probabilities;
    int[] cooldown;

    GameManager gameManager;

    public SpawnerSO spawnerScriptableObject;
    public bool stop;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        prefabs = spawnerScriptableObject.wave1Enemies;
        probabilities = spawnerScriptableObject.Wave1probabilities;
        cooldown = spawnerScriptableObject.Wave1Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            if (gameManager.continueSpawn)
                stop = false;
        }
        else
        {
            if (time >= spawnTime)
            {
                Spawn();
            }
            time += Time.deltaTime;
            if (time > 5 && wave == 1)
            {
                stop = true;
                wave = 2;
                prefabs = spawnerScriptableObject.wave2Enemies;
                probabilities = spawnerScriptableObject.Wave2probabilities;
                cooldown = spawnerScriptableObject.Wave2Cooldown;
                gameManager.continueSpawn = false;
                gameManager.SpawnBoss();
            }
            else if (time > 10 && wave == 2)
            {
                stop = true;
                wave = 3;
                prefabs = spawnerScriptableObject.wave3Enemies;
                probabilities = spawnerScriptableObject.Wave3probabilities;
                cooldown = spawnerScriptableObject.Wave3Cooldown;
                gameManager.continueSpawn = false;
                gameManager.SpawnBoss();
            }
            else if (time > 15 && wave == 3)
            {
                stop = true;
                gameManager.continueSpawn = false;
                gameManager.SpawnBoss();
                //spawn last boss
            }
        }
    }


    void Spawn()
    {
        int random = UnityEngine.Random.Range(0, 1000);
        for(int i = 0; i < probabilities.Length; i++)
        {
            if(random <= probabilities[i])
            {
                spawnTime += cooldown[i];
                SpawnEnemy(prefabs[i]);
            }
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
