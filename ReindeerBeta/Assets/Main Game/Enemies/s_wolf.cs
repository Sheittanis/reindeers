using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class s_wolf : MonoBehaviour
{
    float speed;
    public float timer = 0.0f;
    //snappy movement to fit swiping on phones
    public bool Active;

    public reindeer Ren;
    public control Control;
    public managerScript manager;

    s_score score;

    public float arena_timer = 15.0f;
    public float attack_timer = 0f;
    public Text enemyText;

    public Vector3 currentPoint;
    public Vector3 targetPoint;

    public int tar;
    // Use this for initialization
    void Start()
    {
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        Control = GameObject.Find("Player").GetComponent<control>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();


        speed = 4.0f;
        attack_timer = 0.3f;
        tar = 1;
        currentPoint = new Vector3(-31.5f, 40.0f, 0f);

        Active = false;

        chooseNextPoint();
        ResetArena();

        score = manager.GetComponent<s_score>();
    }

    // Update is called once per frame
    void Update()
    {
        //activity
        if (Active)
        {
            arena_timer -= Time.deltaTime;
            attack_timer -= Time.deltaTime;
            if (attack_timer < 0)
            {
                {
                    //charge
                    chargeAttack();
                }
            }

            //activity timer
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

    public void chargeAttack()
    {
        //find a current position and move towards the target at a preset speed
        transform.position = Vector3.MoveTowards(currentPoint, targetPoint, speed);
        currentPoint = this.transform.position;
        if (this.transform.position == targetPoint)
        {
            //resets the last target to the 1st, keeps a constant pattern
            if (tar == 5)
            {
                tar = 1;
            }

            chooseNextPoint();
            //sometimes pick the same one
            attack_timer = 0.3f;

            tar++;
        }
    }
    public void chooseNextPoint()
    {

        //choose from one of the points
        if (tar == 1)
        {
            targetPoint = new Vector3(-25.0f, 37.0f, 0f);
            GetComponent<SpriteRenderer>().flipX = true; //flips the sprite
            //chargeAttack();
        }
        if (tar == 2)
        {
            targetPoint = new Vector3(-19.0f, 40.0f, 0f);

            //chargeAttack();
        }

        if (tar == 3)
        {
            targetPoint = new Vector3(-25.0f, 43.5f, 0f);
            GetComponent<SpriteRenderer>().flipX = false;//flips the sprite

        }

        if (tar == 4)
        {
            targetPoint = new Vector3(-31.5f, 40.0f, 0f);

        }

    }

    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player")
        {
            //damage the player for 2
            _other.GetComponent<control>().damageMe(2.0f);
        }
    }

    //resets the arena time
    public void ResetArena()
    {
        Active = false;
        arena_timer = 15.0f;
    }
}
