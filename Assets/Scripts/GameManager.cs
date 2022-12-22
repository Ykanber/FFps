using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    PlayerHealth player;
    
    public GameObject[] bossArray;

    int spawnerCount = 1;

    int bossCount = 0;

    public bool continueSpawn;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void SpawnBoss()
    {
        bossCount += 1;
        if (bossCount % spawnerCount == 0)
        {
            if ((bossCount / spawnerCount) - 1 < bossArray.Length)
            {
                Instantiate(bossArray[(bossCount / spawnerCount) - 1], transform);
            }
        }
    }

    public void BossIsDead() 
    {
        Debug.Log(bossCount);
        Debug.Log(spawnerCount); 
        if(bossArray.Length == bossCount / spawnerCount)
        {
            EndGame();
        }
        else
        {
            continueSpawn = true;
        }
    }

    public void EndGame()
    {
        Debug.Log("oldum");
        player.Die();
    }
}
