using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        string path = Application.persistentDataPath + "/player.saved";
        if (!File.Exists(path))
        {
            Button menu = GameObject.Find("Continue button").GetComponent<Button>();
            menu.interactable = false;
            TextMeshProUGUI menuText = menu.GetComponentInChildren<TextMeshProUGUI>();
            menuText.color = new Color32(255, 255, 255, 50);
}
    }

    public void PlayGame()
    {
        SaveSystem.DeleteSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        SaveSystem.LoadPlayer();
        SceneManager.LoadScene(SaveSystem.copyData.level);
        Debug.Log(SaveSystem.copyData.level);
        SaveSystem.isScenebeingLoaded = true;
        Debug.Log("CONTINUE GAME");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}