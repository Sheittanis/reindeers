using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s_bear : MonoBehaviour
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
    public float attack_timer;
    public Text enemyText;

    public bool charge;
    public Vector3 currentPoint;
    public Vector3 targetPoint;
    // Use this for initialization
    void Start()
    {
        //initialize values
        speed = 0.5f;
        attack_timer = 1.5f;
        currentPoint = transform.position;
        charge = false;
        Active = false;

        //Get all the script components required for the functions
        Ren = GameObject.Find("Player").GetComponent<reindeer>();
        Control = GameObject.Find("Player").GetComponent<control>();
        manager = GameObject.Find("Manager").GetComponent<managerScript>();

        chooseRandomPoint();

        //reset the arena.
        ResetArena();

        score = manager.GetComponent<s_score>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Active)
        {
            arena_timer -= Time.deltaTime;
            attack_timer -= Time.deltaTime;

            //Attack timer, when it reaches zero, the bear charges
            if (attack_timer < 0)
            {
                {
                    chargeAttack();
                }
            }

            //Arena timer
            if (arena_timer < 0)
            {
                Active = false; //arena is no longer active
                Ren.transform.position = Control.putMeBack; //puts the player back to the overworld
                manager.battleOrOverworld = false;
                score.score = score.score + 20; //score increase
                ResetArena();
            }
            //Timer text
            //To.string(n2) cuts down to 2 decimal points.
            enemyText.text = "Time: " + arena_timer.ToString("n2");
        }
    }

    public void chargeAttack()
    {
        transform.position = Vector3.MoveTowards(currentPoint, targetPoint, speed);
        currentPoint = this.transform.position;
        if (currentPoint == targetPoint)
        {
            chooseRandomPoint();
        }

        //print(targetPoint);
        //Seek for a new randompoint when it reaches the target
        if (this.transform.position == targetPoint)
        {

            chooseRandomPoint();

            attack_timer = 1.0f;//reset the timer
        }
    }
    public void chooseRandomPoint()
    {
        //Randomly chooses from one of the points
        int tar = Random.Range(1, 5); //range 1 to 4
        //print(tar);
        switch (tar)
        {
            //points preset, always the same
            case 1:
                targetPoint = new Vector3(-19.0f, -37.0f, 0f);
                break;
            case 2:
                targetPoint = new Vector3(-31.5f, -43.5f, 0f);
                break;
            case 3:
                targetPoint = new Vector3(-31.5f, -37.0f, 0f);
                break;
            case 4:
                targetPoint = new Vector3(-19.0f, -43.5f, 0f);
                break;
        }

    }

    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player")
        {
            //damages the player
            _other.GetComponent<control>().damageMe(3.0f);
        }
    }

    public void ResetArena()
    {
        Active = false;
        arena_timer = 15.0f;
    }
}
