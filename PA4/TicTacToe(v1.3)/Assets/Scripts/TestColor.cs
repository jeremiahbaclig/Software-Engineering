using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    private SpriteRenderer background;

    private void Start()
    {
        background = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            applyTheme();
        }
    }

    public void applyTheme()
    {
        if (background.color == Color.white)
        {
            background.color = Color.red;
        }
        else
        {
            background.color = Color.white;
        }
    }
}
