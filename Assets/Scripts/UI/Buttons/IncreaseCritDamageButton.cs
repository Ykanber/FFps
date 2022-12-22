using UnityEngine;
using UnityEngine.UI;

public class IncreaseCritDamageButton : MonoBehaviour
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
        button.onClick.AddListener(delegate { levelUpUI.IncreaseCritDamage("LevelUpIncreaseCritDamagePrefab"); });
    }
}
