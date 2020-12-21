using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {

    int PlayedGameCheck = 0;

    public GameObject MainCanvas;
    public GameObject OptionsCanvas;
   

    public void StartGame ()
        {
        
        OptionsCanvas = GameObject.Find("OptionsCanvas");

           PlayedGameCheck = PlayerPrefs.GetInt("PlayedGameCheck");
        //checks the playerprefs to see if the game has been played before 
           if (PlayedGameCheck == 0)
             {
                //if it hasn't been played before it will open the character select screen and laod into the tutorial level 
                SceneManager.LoadScene("CharSelect");

                // sets the int in player prefs to 1 so that next time it wont trigger the tutorial level
               PlayerPrefs.SetInt("PlayedGameCheck", 1);
             }
           else
             {
                // loads the level select scene
                SceneManager.LoadScene("LevelSelect");
                
                //PlayerPrefs.SetInt("PlayedGameCheck", 0); //used for testing & reseting the int in player prefs

             }
        }
    public void Options ()
    {
        //sets the options canvas to be the child of the music gameobject
        GameObject music = GameObject.Find("Music");
        OptionsCanvas = music.transform.GetChild(0).gameObject;

        //MainCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void Shop ()
    {
        SceneManager.LoadScene("Shop");
       
    }

    public void backtomenu ()
    {
        //turns the options canvas off 
        //MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
