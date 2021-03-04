using UnityEngine;
using UnityEngine.UI;

public class CheckStarter : MonoBehaviour
{
    public GameObject oToggle;
    public static int turn = 0;

    void Update()
    {
        ChooseStarter(oToggle);
    }

    private void ChooseStarter(GameObject oToggle)
    {
        if (GameObject.FindGameObjectsWithTag("Respawn")[0].GetComponent<Toggle>().isOn == true)
        {
            turn++;
        }
    }
}
