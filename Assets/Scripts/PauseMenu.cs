using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pauseMenu;

   public void Pause() //Pause logic
   {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
   }

   public void Home() //to go back to start screen
   {
        SceneManager.LoadScene("Start Screen");
        Time.timeScale = 1;
   }

    public void Resume() //To resume the game
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart() //To reload the scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
