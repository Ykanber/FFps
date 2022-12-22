using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Player player;

    LevelUpPrefabSpawner levelUpPrefabSpawner;

    [SerializeField] GameObject pistol;
    [SerializeField] GameObject Sheriff;
    [SerializeField] GameObject SMG;
    [SerializeField] GameObject rifle;


    private void Awake()
    {
        levelUpPrefabSpawner = FindObjectOfType<LevelUpPrefabSpawner>();
    }
    public void IncreaseGunMagazine(string name)
    {
        Time.timeScale = 1;
        player.Gun.GetComponent<Gun>().IncreaseGunMagazine();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }

    public void IncreaseReloadSpeed(string name)
    {
        Time.timeScale = 1;
        player.Gun.GetComponent<Gun>().IncreaseReloadSpeed();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }   
    public void IncreaseGunDamage(string name)
    {
        Time.timeScale = 1;
        player.Gun.GetComponent<Gun>().IncreaseGunBaseDamage();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }

    public void IncreaseCritChance(string name)
    {
        Time.timeScale = 1;
        player.Gun.GetComponent<Gun>().IncreaseCritChance();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }

    public void IncreaseCritDamage(string name)
    {
        Time.timeScale = 1;
        player.Gun.GetComponent<Gun>().IncreaseCritDamage();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }

    public void ChangeGunToRifle(string name)
    {
        Time.timeScale = 1;
        player.Gun.SetActive(false);
        player.Gun = rifle;
        player.Gun.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        RemovePrefab(name);
    }


    void RemovePrefab(string name)
    {
        int index = 1;
        for (int i = 0; i < levelUpPrefabSpawner.levelUpUpgradesPrefabs.Count; i++)
        {
            if(levelUpPrefabSpawner.levelUpUpgradesPrefabs[i].name == name)
            {
                index = i;
                break;
            }
        }
        levelUpPrefabSpawner.levelUpUpgradesPrefabsCount[index]--;
        if (levelUpPrefabSpawner.levelUpUpgradesPrefabsCount[index] == 0)
        {
            levelUpPrefabSpawner.levelUpUpgradesPrefabs.RemoveAt(index);
            levelUpPrefabSpawner.levelUpUpgradesPrefabsCount.RemoveAt(index);
        }
    }


}
