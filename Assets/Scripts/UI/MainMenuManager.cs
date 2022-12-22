using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public Button continueButton;

    void Awake()
    {
        string path = Application.persistentDataPath + "/Player.yek";
        if (File.Exists(path))
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }

    public void NewGameButton()
    {
        string path = Application.persistentDataPath + "/Player.yek";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        Player tempPlayer = new Player();
        SaveSystem.SavePlayer(tempPlayer);
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
