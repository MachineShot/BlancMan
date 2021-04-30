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
        string path = Application.persistentDataPath + "/player.isgay";
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveSystem.isScenebeingLoaded = true;
        Debug.Log("CONTINUE GAME");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}