using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
    public GameObject PauseCanvas;

    public GameObject OptionsCanvas;

    public GameObject PauseButtonCanvas;

	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
        //sets the key to press to open the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //stops the game and opens the pause canvas 
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            
        }
	}

    public void ReturnToGame()
    {
        //starts the game again disables the pause canvas and renables the pause button
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
        PauseButtonCanvas.SetActive(true);
    }

    public void Options ()
    {
        //does the same as options menu on main menu
        GameObject music = GameObject.Find("Music");
        OptionsCanvas = music.transform.GetChild(0).gameObject;

       // PauseCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);

    }
    
    public void BackToMainMenu ()
    {
        //resets the time scale and takes the player to the main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        
    }

    public void OpenpauseCanvas()
    {
        // this pause function will be used on mobile devices and attached to a button 
        //stops the game, opens pause canvas and removes the pause button 
        Time.timeScale = 0;

        PauseCanvas.SetActive(true);
        PauseButtonCanvas.SetActive(false);
    }

  

    public void BackToPause()
    {
        // closes the options canvas and reopens the pause buttons 
        PauseCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }
}
