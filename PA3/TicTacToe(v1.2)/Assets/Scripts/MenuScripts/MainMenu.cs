using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    GridManager gridClass = new GridManager();

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

            Debug.Log("m: " + m + " n: " + n + " k: " +  k);

            gridClass.m = Int32.Parse(m);
            gridClass.n = Int32.Parse(n);
            gridClass.k = Int32.Parse(k);
        } catch (Exception ex)
        {
            return;
        }
    }
}
