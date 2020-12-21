using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s_gingerman : MonoBehaviour
{
    public float arena_timer = 15.0f;

    public GameObject spawner;
    public managerScript manager;

    public bool Active;
    public reindeer Ren;
    public control Control;
    public s_score score;

    public Text enemyText;

    public void Start()
    {
        Active = false;
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();
        Control = GameObject.Find("Player").GetComponent<control>();
    }

    public void Update()
    {
        if (Active)
        {
            arena_timer -= Time.deltaTime;
            if (arena_timer < 0)
            {
                manager.battleOrOverworld = false;
                Ren.transform.position = Control.putMeBack; //puts the player back

                //score.score = score.score + 20;
                //no need for score update, Player gets score through buffs
                ResetArena();
            }
        }
        //Timer text
        //To.string(n2) cuts down to 2 decimal points.
        enemyText.text = "Time: " + arena_timer.ToString("n2");
    }


    public void ResetArena()
    {
        arena_timer = 15.0f;
        Active = false;
    }
}
