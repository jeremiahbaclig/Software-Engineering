using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 60;
    [SerializeField] Text gameTimer;
    bool timerUnPaused = true;

    void Start() {
        currentTime = startTime;
    }

    void Update() {
        if (timerUnPaused) {
            currentTime -= 1 * Time.deltaTime;
            gameTimer.text = currentTime.ToString("0");
        }

        if (currentTime <= 0) {
            SceneManager.LoadScene("TimerOutScene");
        }
    }

    public void PauseTimer() {
        timerUnPaused = !timerUnPaused;

    }

    public void QuitCurrentGame() {
        SceneManager.LoadScene("Menu");
    }


}
