using UnityEngine;
using UnityEngine.UI;

public class IncreaseDamageButton : MonoBehaviour
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
        button.onClick.AddListener(delegate { levelUpUI.IncreaseGunDamage("LevelUpIncreaseDamagePrefab"); });
    }

}
