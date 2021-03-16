using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

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

    public void SinglePlayerStartUpMenu() {
        SceneManager.LoadScene("SinglePlayerStartUp");
    }

    public void SubmitPressed()
    {
        if (GridManager.m < 3 || GridManager.n < 3 || GridManager.k < 3 ||
                GridManager.m > 20 || GridManager.n > 20 || GridManager.n > 20)
        {
            EditorUtility.DisplayDialog("User Input Error!",
                "Values must be between 3 and 20! (inclusive)", "OK", "Cancel");

            SceneManager.LoadScene("Menu");
        }
    }

    private void Update()
    {
        GameObject inputM = GameObject.Find("m");
        GameObject inputN = GameObject.Find("n");
        GameObject inputK = GameObject.Find("k");

        try
        {
            string m = inputM.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            string n = inputN.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            string k = inputK.transform.GetChild(2).gameObject.GetComponent<Text>().text;

            GridManager.m = Int32.Parse(m);
            GridManager.n = Int32.Parse(n);
            GridManager.k = Int32.Parse(k);
        } catch (Exception ex)
        {
            if(ex is NullReferenceException) {
                return;
            }
            else if(ex is FormatException)
            {
                GridManager.m = 99;
                return;
            }
            else
            {
                Debug.Log(ex);
                return;
            }
        }
    }
}
