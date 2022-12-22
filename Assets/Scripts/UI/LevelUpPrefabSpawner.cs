using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPrefabSpawner : MonoBehaviour
{
    public List<GameObject> levelUpUpgradesPrefabs;
    public List<int> levelUpUpgradesPrefabsCount;


    List<GameObject> instantiatedPrefabs = new List<GameObject>();
    
    private void OnEnable()
    {
        int iteration = 0;
        List<int> takenValues = new List<int>();
        while (takenValues.Count != levelUpUpgradesPrefabsCount.Count && takenValues.Count != 3)
        {
            int randomNumber = 20;
            iteration++;
            while (true) {
                randomNumber = Random.Range(0, levelUpUpgradesPrefabsCount.Count);
                iteration++;
                if (!takenValues.Contains(randomNumber)){
                    takenValues.Add(randomNumber);
                    break;
                }
            }
            GameObject gobject = Instantiate(levelUpUpgradesPrefabs[randomNumber], transform);
            instantiatedPrefabs.Add(gobject);
        }
    }
    
    private void OnDisable()
    {
        while (instantiatedPrefabs.Count != 0 )
        {
            Destroy(instantiatedPrefabs[0]);
            instantiatedPrefabs.RemoveAt(0);
        }
    }
    
}
