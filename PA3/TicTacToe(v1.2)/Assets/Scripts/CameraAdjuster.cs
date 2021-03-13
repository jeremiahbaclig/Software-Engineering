using UnityEngine;
using System;

public class CameraAdjuster : MonoBehaviour
{
    GridManager gridClass = new GridManager();

    void Start()
    {
        Camera.main.orthographicSize = 5.0F;
    }

    public void Adjust(int m, int n)
    {
        float formula = 2 * (m + n) / 2;
        if (Camera.main.orthographicSize < formula)
        {
            if (formula >= 20)
            {
                float temp = formula / 10;
                formula += temp;
            }
            Camera.main.orthographicSize = formula;
        }
        else
        {
            return;
        }
    }
}
