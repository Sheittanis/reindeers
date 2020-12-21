using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    bool kramp;

    //For manipulating player if needed
    public GameObject player;

    //Whether or not we are in battle mode, true = battle, false = overworld
    public bool battleOrOverworld = false;

    //Can the player move?
    public bool canMove;

    //For the battle arena
    public GameObject arena;
    public Vector3 arenaLocation = new Vector3(0, 0, 0);

    public s_admob ads;

    public enum EnemyType
    {
        elf,
        penguin,
        bear,
        gingerman,
        wolf,
        krampus
    };
    public EnemyType EnemyChosen;
    public EnemyType DefaultEnemy = EnemyType.elf;

    void Start()
    {
        ads = GameObject.Find("Ads").GetComponent<s_admob>();
        //Load the level that was selected
        this.GetComponent<LevelGen>().loadLevel(PlayerPrefs.GetInt("levelToPlay"));

        //Start the intro dialouge for this level
        this.GetComponent<dialouge>().playIntro(PlayerPrefs.GetInt("levelToPlay"));

        //Set the players head to the correct image
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("CharacterSelect/Heads/" + player.GetComponent<reindeer>().id);

    }

    public void ChooseEnemy()
    {

        switch (EnemyChosen)
        {
            case EnemyType.elf:
                arenaLocation = new Vector3(-25.0f, 0.0f, 0.0f);
                break;
            case EnemyType.gingerman:
                arenaLocation = new Vector3(-25.0f, 20.0f, 0.0f);
                break;
            case EnemyType.penguin:
                arenaLocation = new Vector3(-25.0f, -20.0f, 0.0f);
                break;
            case EnemyType.bear:
                arenaLocation = new Vector3(-25.0f, -40.0f, 0.0f);
                break;
            case EnemyType.wolf:
                arenaLocation = new Vector3(-25.0f, 40.0f, 0.0f);
                break;
            case EnemyType.krampus:
                arenaLocation = new Vector3(-50.0f, 0.0f, 0.0f);
                kramp = true;
                break;
        }
    }


    void Update()
    {


        if (battleOrOverworld)
        {
            //Centre on arena in battle mode
            transform.position = arenaLocation + Vector3.forward * -10;
            Camera.main.orthographicSize = 5.0f;
            if(kramp)
            {
                Camera.main.orthographicSize = 7.3f;
            }
        }
        else
        {
            //Keep this (and the camera) on top of the player when not in battle mode
            transform.position = player.transform.position + Vector3.forward * -10;
            Camera.main.orthographicSize = 4.0f;
        }
    }

    public void endLevel()
    {
        //Set the level completed to this level (if it is the new highest completed level) to be used in unlocking level, music and reindeer
        if (PlayerPrefs.GetInt("levelToPlay") > PlayerPrefs.GetInt("levelsBeat"))
        {
            PlayerPrefs.SetInt("levelsBeat", PlayerPrefs.GetInt("levelToPlay"));
        }

        //Remember the score
        PlayerPrefs.SetInt("previousScore", this.GetComponent<s_score>().endScore());
        
        //Load leaderboard screen.
        SceneManager.LoadScene("Leaderboard");
    }
}
