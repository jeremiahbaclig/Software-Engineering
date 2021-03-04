using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{ 
     
   public void PlayAgain() {
        SceneManager.LoadScene("StartUpScene");
   }

   public void ReturnToMenu() {
        SceneManager.LoadScene("Menu");
   }

}
