using UnityEngine;
using UnityEngine.UI;

public class IncreaseCritChanceButton : MonoBehaviour
{
    Button button;
    LevelUpUI levelUpUI;
    void Awake()
    {
        levelUpUI = FindObjectOfType<LevelUpUI>();
        button = GetComponent<Button>();
        Click();
    }

    void Click()
    {
        button.onClick.AddListener(delegate { levelUpUI.IncreaseCritChance("LevelUpIncreaseCritChancePrefab"); });
    }
}
