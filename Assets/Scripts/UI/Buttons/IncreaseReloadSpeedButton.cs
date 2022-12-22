using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseReloadSpeedButton : MonoBehaviour
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
        button.onClick.AddListener(delegate { levelUpUI.IncreaseReloadSpeed("LevelUpIncreaseReloadSpeedPrefab"); });
    }

}
