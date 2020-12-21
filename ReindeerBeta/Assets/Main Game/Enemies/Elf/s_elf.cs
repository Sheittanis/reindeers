using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s_elf : MonoBehaviour
{
    public float elf_health = 30f;
    public float timer = 0.0f;
    //snappy movement to fit swiping on phones
    public bool Active;

    public reindeer Ren;
    public control Control;
    public managerScript manager;

    public float x;
    public float y;
    public Vector2 pos;

    s_score score;

    public float arena_timer = 15.0f;
    public Text enemyText;
    public void Start()
    {
        Active = false;
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        Control = GameObject.Find("Player").GetComponent<control>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();

        ResetArena();

        score = manager.GetComponent<s_score>();
    }



    public void Update()
    {
        //checks if the arena is active
        if (Active)
        {
            if (elf_health < 0)
            {
                Active = false;
                Ren.transform.position = Control.putMeBack;
                manager.battleOrOverworld = false;
                score.score = score.score + 20;
                ResetArena();
            }

            //arena activity timer
            arena_timer -= Time.deltaTime;
            if (arena_timer < 0)
            {
                Active = false;
                Ren.transform.position = Control.putMeBack;
                manager.battleOrOverworld = false;
                score.score = score.score + 20;
                ResetArena();
            }
            //Timer text
            //To.string(n2) cuts down to 2 decimal points.
            enemyText.text = "Time: " + arena_timer.ToString("n2");
        }
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            //elf health is reduced each time its hit by the player
            elf_health = elf_health - 10.0f;

            //random range within the arena

            x = Random.Range(-30.0f, -20.0f);
            y = Random.Range(-3.5f, 3.5f);
            pos = new Vector2(x, y);
            //the elf blinks each time its hit
            this.transform.position = pos;

        }
    }


    public void ResetArena()
    {
        //arena reset. All the positions, timers etc
        x = Random.Range(-30.0f, -20.0f);
        y = Random.Range(-3.5f, 3.5f);
        pos = new Vector2(x, y);

        this.transform.position = pos;

        arena_timer = 15.0f;
        elf_health = 30.0f;
    }
}
