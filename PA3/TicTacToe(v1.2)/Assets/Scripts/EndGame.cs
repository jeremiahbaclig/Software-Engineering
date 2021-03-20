using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{ 
   public void PlayAgain() {
        SoundManager.PlaySound("select_yes");
        SceneManager.LoadScene("GameScene");
   }

   public void ReturnToMenu() {
        SoundManager.PlaySound("select_no");
        SceneManager.LoadScene("Menu");
   }

}
