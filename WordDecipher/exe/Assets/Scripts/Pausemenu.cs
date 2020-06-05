/*
 * This class activates the panel with buttons RESUME,MENU,QUIT and implements methods used by these buttons
 * Ta klasa aktywuje panel z przyciskami RESUME, MENU, QUIT i implementuje metody używane przez te przyciski
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{

    public static bool gameispaused = false; //represents that panel with buttons is visible 
    public GameObject pausemenuui; // this object represent panel with buttons
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //check if key ESC is pressed
        {
            if (gameispaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume() //method that set panel invisible
    {
        pausemenuui.SetActive(false);
        gameispaused = false;
    }
    void Pause() //method that set panel visible
    {
       
        pausemenuui.SetActive(true);
        gameispaused = true;
    }
    public void Quitgame() //method that closes the game activated by the button QUIT
    {
        Application.Quit();
    }
    public void RestartGame()//method that restart the game activated by the button MENU
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
