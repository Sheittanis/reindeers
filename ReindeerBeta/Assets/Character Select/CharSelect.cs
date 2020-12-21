using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour {
    public GameObject playButton;
    public GameObject backbut;

    //The reindeer that is being displayed to the user and will be selected when play is pressed
    reindeer selected;

    //The head icon of the selected reindeer
    public GameObject head;

    //The text box of the selected reindeers name
    public GameObject charName;

    //The star images representing all the stats
    public GameObject overWorldSpeedStars;
    public GameObject battleSpeedStars;
    public GameObject turnabilityStars;
    public GameObject jumpStars;
    public GameObject damageStars;
    public GameObject defenceStars;
    public GameObject healthStars;

    public GameObject loadingcanvas;

    void Start () {
        //For resetting stuff (not used in game)
        PlayerPrefs.SetInt("levelsBeat", 25);
        //PlayerPrefs.SetInt("levelToPlay", 0);
        PlayerPrefs.SetInt("PlayedGameCheck", 1);

        //Set selected, default to dasher
        selected = this.GetComponent<reindeer>();
        selected.setReindeer(selected.donner);

    }

    string _displayMe = "not been set";

    //Display the current reindeer
    void Update () {
        //To stop the god damn bug
        backbut.transform.GetChild(0).GetComponent<Text>().text = "Back";

        //Display head using id and resources folder
        head.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("CharacterSelect/Heads/" + selected.id);

        //Display name using the id and a switch statement
        switch (selected.id)
        {
            case 0:
                if (PlayerPrefs.GetInt("levelsBeat") >= 3)
                {
                    _displayMe = "<color=orange>Dasher</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 3 TO UNLOCK</color>";
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("levelsBeat") >= 6)
                {
                    _displayMe = "<color=purple>Dancer</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 6 TO UNLOCK</color>";
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("levelsBeat") >= 9)
                {
                    _displayMe = "<color=green>Prancer</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 9 TO UNLOCK</color>";
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("levelsBeat") >= 12)
                {
                    _displayMe = "<color=white>Vixen</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 12 TO UNLOCK</color>";
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("levelsBeat") >= 15)
                {
                    _displayMe = "<color=lightblue>Comet</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 15 TO UNLOCK</color>";
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("levelsBeat") >= 18)
                {
                    _displayMe = "<color=fuchsia>Cupid</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 18 TO UNLOCK</color>";
                }
                break;
            case 6:
                _displayMe = "<color=grey>Donner</color>";
                break;
            case 7:
                if (PlayerPrefs.GetInt("levelsBeat") >= 21)
                {
                    _displayMe = "<color=yellow>Blitzen</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 21 TO UNLOCK</color>";
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("levelsBeat") >= 24)
                {
                    _displayMe = "<color=red>Rudolph</color>";
                }
                else
                {
                    _displayMe = "<color=black>BEAT LEVEL 24 TO UNLOCK</color>";
                }
                break;
            default:
                break;
        }
        charName.GetComponent<Text>().text = _displayMe;
        //Display stats
        overWorldSpeedStars.GetComponent<Image>().fillAmount = selected.stars[0] / 5.0f;
        battleSpeedStars.GetComponent<Image>().fillAmount = selected.stars[1] / 5.0f;
        turnabilityStars.GetComponent<Image>().fillAmount = selected.stars[2] / 5.0f;
        jumpStars.GetComponent<Image>().fillAmount = selected.stars[3] / 5.0f;
        damageStars.GetComponent<Image>().fillAmount = selected.stars[4] / 5.0f;
        defenceStars.GetComponent<Image>().fillAmount = selected.stars[5] / 5.0f;
        healthStars.GetComponent<Image>().fillAmount = selected.stars[6] / 5.0f;
        
        playButton.GetComponent<blockme>().blocked = _displayMe.StartsWith("<color=black>BEAT ");

      
        
    }

   

    //Left button pressed, rotate selection back
    public void onLeftPress()
    {
        switch (selected.id)
        {
            case 0:
                selected.setReindeer(selected.rudolph);
                break;
            case 1:
                selected.setReindeer(selected.dasher);
                break;
            case 2:
                selected.setReindeer(selected.dancer);
                break;
            case 3:
                selected.setReindeer(selected.prancer);
                break;
            case 4:
                selected.setReindeer(selected.vixen);
                break;
            case 5:
                selected.setReindeer(selected.comet);
                break;
            case 6:
                selected.setReindeer(selected.cupid);
                break;
            case 7:
                selected.setReindeer(selected.donner);
                break;
            case 8:
                selected.setReindeer(selected.blitzen);
                break;
            default:
                break;
        }
    }

    //Right button pressed, rotate selection forward
    public void onRightPress()
    {
        switch (selected.id)
        {
            case 0:
                selected.setReindeer(selected.dancer);
                break;
            case 1:
                selected.setReindeer(selected.prancer);
                break;
            case 2:
                selected.setReindeer(selected.vixen);
                break;
            case 3:
                selected.setReindeer(selected.comet);
                break;
            case 4:
                selected.setReindeer(selected.cupid);
                break;
            case 5:
                selected.setReindeer(selected.donner);
                break;
            case 6:
                selected.setReindeer(selected.blitzen);
                break;
            case 7:
                selected.setReindeer(selected.rudolph);
                break;
            case 8:
                selected.setReindeer(selected.dasher);
                break;
            default:
                break;
        }
    }

    //Play pressed, set player prefab of selected reindeer, open the level scene.
    public void play()
    {
        //Only work on unlocked reindeer
        if (!_displayMe.StartsWith("<color=black>BEAT "))
        {

            //Set the reindeer playerpref. Load level.
            switch (selected.id)
            {

                case 0:
                    PlayerPrefs.SetString("reindeerForPlayer", "dasher");
                    break;
                case 1:
                    PlayerPrefs.SetString("reindeerForPlayer", "dancer");
                    break;
                case 2:
                    PlayerPrefs.SetString("reindeerForPlayer", "prancer");
                    break;
                case 3:
                    PlayerPrefs.SetString("reindeerForPlayer", "vixen");
                    break;
                case 4:
                    PlayerPrefs.SetString("reindeerForPlayer", "comet");
                    break;
                case 5:
                    PlayerPrefs.SetString("reindeerForPlayer", "cupid");
                    break;
                case 6:
                    PlayerPrefs.SetString("reindeerForPlayer", "donner");
                    break;
                case 7:
                    PlayerPrefs.SetString("reindeerForPlayer", "blitzen");
                    break;
                case 8:
                    PlayerPrefs.SetString("reindeerForPlayer", "rudolph");
                    break;
                default:
                    break;
            }
            GameObject.Find("Music").GetComponent<musicManager>().inGame = true;
            // Opens the loading screen canvas and then starts the coroutine that will asynchronously load the next level 
            loadingcanvas.SetActive(true);

            StartCoroutine(start());
            
        }      

          
    }
    IEnumerator start()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Levels");
        yield return async;
    }

    //Back pressed, return to level select
    public void back()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
