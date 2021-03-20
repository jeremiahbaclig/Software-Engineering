using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public void ExitGame() {
        SoundManager.PlaySound("select_no");
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void StartGame() {
        SoundManager.PlaySound("select_yes");
        SceneManager.LoadScene("GameScene");
    }

    public void StartUpMenu() {
        SoundManager.PlaySound("intro");
        SceneManager.LoadScene("StartUpScene");
        GridManager.single = false;
    }

    public void GoBackToMenu() {
        SoundManager.PlaySound("select_no");
        SceneManager.LoadScene("Menu");
    }

    public void SinglePlayerStartUpMenu() {
        SoundManager.PlaySound("intro");
        SceneManager.LoadScene("SinglePlayerStartUp");
        GridManager.single = true;
    }

    public void SubmitPressed()
    {
        if (GridManager.m < 2 || GridManager.n < 2 || GridManager.k < 2 ||
                GridManager.m > 50 || GridManager.n > 50 || GridManager.k > 50)
        {
            EditorUtility.DisplayDialog("User Input Error!",
                "Values must be between 2 and 50! (inclusive)", "OK", "Cancel");
            SoundManager.PlaySound("select_no");
            SceneManager.LoadScene("Menu");
        }
        else if (GridManager.k > GridManager.m || GridManager.k > GridManager.n)
        {
            EditorUtility.DisplayDialog("User Input Error!",
                "K must be less than m or n!", "OK", "Cancel");
            SoundManager.PlaySound("select_no");
            SceneManager.LoadScene("Menu");
        }
        else if (Math.Abs(GridManager.m - GridManager.n) > 10)
        {
            EditorUtility.DisplayDialog("User Input Error!",
                "M and n are too far apart! This makes for a bad playing experience.", "OK", "Cancel");
            SoundManager.PlaySound("select_no");
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
