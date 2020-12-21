using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class s_krampus : MonoBehaviour
{
    public float arena_timer;
    //snappy movement to fit swiping on phones
    public bool Active;

    public reindeer Ren;
    public control Control;
    public managerScript manager;
    s_score score;

    public Text enemyText;
    public void Start()
    {
        //different arena timer from the rest, 30 seconds, final boss
        arena_timer = 30.0f;
        Active = false;
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        Control = GameObject.Find("Player").GetComponent<control>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();

        score = manager.GetComponent<s_score>();
    }



    // Update is called once per frame
    public void Update()
    {
        //checks if the arena is active, (ie player hit the overworld krampus)
        if (Active)
        {
            arena_timer -= Time.deltaTime;
        }
        if (arena_timer < 0)
        {
            Active = false;
            arena_timer = 1;
            Ren.transform.position = Control.putMeBack;
            manager.battleOrOverworld = false;
            //woo, 1000 score for finishing
            score.score = score.score + 1000;

            //specific music for krampus
            GameObject.Find("Music").GetComponent<musicManager>().krampusdead();
        }
        //Timer text
        //To.string(n2) cuts down to 2 decimal points.
        enemyText.text = "Time: " + arena_timer.ToString("n2");
    }
}
