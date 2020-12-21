using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s_pengu : MonoBehaviour
{

    public float timer = 0.0f;
    public float arena_timer = 15.0f;
    public Vector3 spawn_pos;

    public GameObject spawner;
    public managerScript manager;

    public bool Active;

    s_score score;
    public reindeer Ren;
    public control Control;
    public Text enemyText;
    public void Start()
    {
        Active = false;
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        Control = GameObject.Find("Player").GetComponent<control>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();


        score = manager.GetComponent<s_score>();
    }

    public void Update()
    {
        //activity check
        if (Active)
        {
            timer -= Time.deltaTime;
            arena_timer -= Time.deltaTime;
            //timer that will move the penguin
            if (timer < 0)
            {
                movement();
            }

            if (arena_timer < 0)
            {
                //get out of the arena
                Active = false;
                Ren.transform.position = Control.putMeBack; //port the player back
                manager.battleOrOverworld = false;
                score.score = score.score + 20; //20 points!
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

    public void movement()
    {
        //random movement on the X axis
        Vector3 position = new Vector3(Random.Range(-5.5f, 5.5f), -20f, 0f);
        spawn_pos.x = position.x + spawner.transform.position.x;
        spawn_pos.y = spawner.transform.position.y + 4.0f;
        this.transform.position = spawn_pos;
        timer = 0.5f; //resets timer

    }
}
