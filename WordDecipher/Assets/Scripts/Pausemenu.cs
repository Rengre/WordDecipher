﻿/*
 * This class activates the panel with buttons RESUME,MENU,QUIT and implements methods used by these buttons
 * Ta klasa aktywuje panel z przyciskami RESUME, MENU, QUIT i implementuje metody używane przez te przyciski
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //represents that panel with buttons is visible 
    public GameObject pauseMenuPanel; // this object represent panel with buttons
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //check if key ESC is pressed
        {
            if (gameIsPaused)
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
        pauseMenuPanel.SetActive(false);
        gameIsPaused = false;
    }

    void Pause() //method that set panel visible
    {
        pauseMenuPanel.SetActive(true);
        gameIsPaused = true;
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
