using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 60;
    [SerializeField] Text gameTimer;
    bool timerPaused = false;

    void Start() {
        currentTime = startTime;
    }

    void Update() {
        currentTime -= 1 * Time.deltaTime;
        gameTimer.text = currentTime.ToString("0");

        if (currentTime <= 0) {
            currentTime = 0;
        }
    }

    public void pauseTimer() {
        timerPaused = !timerPaused;
    }



}
