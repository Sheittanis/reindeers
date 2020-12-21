using UnityEngine;
using System.Collections;

public class wolf : MonoBehaviour {

    //Manager for checking whether in battle or overworld for movement functions
    managerScript Manager;
    GameObject player;
    

    //battleMode
    public s_wolf wolfy;

    void Start()
    {
        //get manager player and battle mode
        Manager = GameObject.Find("Manager").GetComponent<managerScript>();
        player = Manager.player;
        wolfy = GameObject.Find("wolf").GetComponent<s_wolf>();
    }
    
    void Update()
    {
        //Move towards player
        Vector2 this2d = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 play2d = new Vector2(player.transform.position.x, player.transform.position.y);

        //look at player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5.0f * Time.deltaTime);
        if (play2d.x - this2d.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.name == "Player")
        {
            Manager.EnemyChosen = managerScript.EnemyType.wolf;
            Manager.ChooseEnemy();
            //Save the players return position
            _other.gameObject.GetComponent<control>().putMeBack = this.transform.position;
            //Change to battlemode
            Manager.battleOrOverworld = true;

            //Move player
            _other.transform.position = Manager.arenaLocation - 1.5f * Vector3.up;
            wolfy.Active = true;


            Destroy(this.gameObject);
        }
    }
}