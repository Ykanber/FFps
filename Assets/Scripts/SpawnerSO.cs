using UnityEngine;


[CreateAssetMenu(fileName ="Spawner", menuName ="ScriptableObjects/SpawnerManagerScriptableObject")]
public class SpawnerSO : ScriptableObject
{

    public GameObject[] wave1Enemies;
    [SerializeField] int[] wave1probabilities;
    [SerializeField] int[] wave1Cooldown;
    
    public GameObject[] wave2Enemies;
    [SerializeField] int[] wave2probabilities;
    [SerializeField] int[] wave2Cooldown;
    
    public GameObject[] wave3Enemies;
    [SerializeField] int[] wave3probabilities;
    [SerializeField] int[] wave3Cooldown;

    public int[] Wave1probabilities { get => wave1probabilities;}
    public int[] Wave1Cooldown { get => wave1Cooldown; }
    public int[] Wave2probabilities { get => wave2probabilities;}
    public int[] Wave2Cooldown { get => wave2Cooldown; }
    public int[] Wave3probabilities { get => wave3probabilities;}
    public int[] Wave3Cooldown { get => wave3Cooldown; }
}
