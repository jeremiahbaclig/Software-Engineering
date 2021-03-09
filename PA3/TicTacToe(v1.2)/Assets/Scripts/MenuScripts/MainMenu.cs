using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame() {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void StartUpMenu() {
        SceneManager.LoadScene("StartUpScene");
    }

    public void GoBackToMenu() {
        SceneManager.LoadScene("Menu");
    }

}
