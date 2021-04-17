using UnityEngine;

public class Scene : MonoBehaviour, SceneFactory
{
    private SpriteRenderer background;
    private int currentTheme;

    private void Start()
    {
        background = GetComponent<SpriteRenderer>();
        currentTheme = 0;
    }

    private void Update()
    {
        if (currentTheme != MainMenu.currentTheme)
        {
            applyTheme();
        }
        else if (background.color == Color.white)
        {
            applyTheme();
        }
    }

    public void applyTheme()
    {
        currentTheme = MainMenu.currentTheme;
        switch (currentTheme)
        {
            case 0:
                background.color = new Color(1, 1, 1, 1);
                break;
            case 1:
                background.color = new Color(1, 0.3f, 0.4f, 1);
                break;
            case 2:
                background.color = new Color(0.1f, 0.6f, 0.4f, 1);
                break;
            default:
                break;
        }
    }

}
