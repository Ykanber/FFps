using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UpgradeMenu : MonoBehaviour
{
    int upgradeMaterial;
    int hpLevel;
    int pistolMastery;
    int rifleMastery;
    int deathCount;

    public TextMeshProUGUI hpLevelText;
    public TextMeshProUGUI pistolMasteryText;
    public TextMeshProUGUI rifleMasteryText;
    public TextMeshProUGUI upgradeMaterialText;
    public TextMeshProUGUI deathCountText;

    private void Awake()
    {
        TakeData();
    }

    public void IncreaseHPLevel()
    {
        if(upgradeMaterial  > 0 && hpLevel < 4)
        {
            upgradeMaterial--;
            hpLevel++;
            hpLevelText.text = hpLevel.ToString();
            upgradeMaterialText.text = upgradeMaterial.ToString();
        }
    }

    public void IncreaseRifleMastery()
    {
        if (upgradeMaterial > 0 && rifleMastery < 4)
        {
            upgradeMaterial--;
            rifleMastery++;
            rifleMasteryText.text = rifleMastery.ToString();
            upgradeMaterialText.text = upgradeMaterial.ToString();
        }
    }

    public void IncreasePistolMastery()
    {
        if (upgradeMaterial > 0 && pistolMastery < 4)
        {
            upgradeMaterial--;
            pistolMastery++;
            pistolMasteryText.text = pistolMastery.ToString();
            upgradeMaterialText.text = upgradeMaterial.ToString();
        }
    }

    public void RevertButton()
    {
        TakeData();
    }

    public void PlayButton()
    {
        SaveData();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }

    void TakeData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        hpLevel = data.hpLevel;
        pistolMastery = data.pistolMastery;
        rifleMastery = data.rifleMastery;
        upgradeMaterial = data.upgradeMaterial;
        deathCount = data.deathCount;

        deathCountText.text = deathCount.ToString();
        hpLevelText.text = hpLevel.ToString();
        pistolMasteryText.text = pistolMastery.ToString();
        rifleMasteryText.text = rifleMastery.ToString();
        upgradeMaterialText.text = upgradeMaterial.ToString();
    }

    void SaveData()
    {
        Player tempPlayer = new Player();
        tempPlayer.hpLevel = hpLevel;
        tempPlayer.pistolMastery = pistolMastery;
        tempPlayer.rifleMastery = rifleMastery;
        tempPlayer.deathCount = deathCount;
        tempPlayer.upgradeMaterial = upgradeMaterial;
        SaveSystem.SavePlayer(tempPlayer);
    }
}
