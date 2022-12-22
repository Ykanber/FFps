using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpLwHealthUI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI LwText;

    [SerializeField] Slider expSlider;
    [SerializeField] Slider HealthSlider;

    // UI
    [SerializeField] GameObject LevelUpUI;

    private void Awake()
    {
        ChangeexpSlider(0);
        ChangeHealthSlider(1);
    }

    public void ChangeLwText(int text)
    {
        Time.timeScale = 0;
        LwText.text = text.ToString();
        LevelUpUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ChangeexpSlider(float amount)
    {
        expSlider.value = amount;
    }

    public void ChangeHealthSlider(float amount)
    {
        HealthSlider.value = amount;
    }

}
