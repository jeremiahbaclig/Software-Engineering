using UnityEngine;
using UnityEngine.UI;

public class CheckStarter : MonoBehaviour
{
    public static int turn = 0;

    void Update()
    {
        ChooseStarter();
    }

    private void ChooseStarter()
    {
        if (GameObject.FindGameObjectsWithTag("Respawn")[0].GetComponent<Toggle>().isOn == true)
        {
            turn = 0;
            GridManager.cpuStart = true;
        }
        else if (GameObject.FindGameObjectsWithTag("Respawn_X")[0].GetComponent<Toggle>().isOn == true)
        {
            turn = 1;
            GridManager.cpuStart = false;
        }
    }
}
