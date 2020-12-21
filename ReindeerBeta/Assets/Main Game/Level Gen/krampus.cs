using UnityEngine;
using System.Collections;

public class krampus : MonoBehaviour {

    //Manager for checking whether in battle or overworld for movement functions
    managerScript Manager;

    float angle = 0.0f;
    float speed = 1.5f;
    float halfrange = 0.5f;
    Color mid;
    
    //Battle mode
    public s_krampus kramp;
    
    void Start()
    {
        //Set colour
        mid = new Color(1.0f, 1 - halfrange, 1 - halfrange, 1.0f);
        this.GetComponent<SpriteRenderer>().color = mid;
        
        //Get manager and battle version
        Manager = GameObject.Find("Manager").GetComponent<managerScript>();
        kramp = GameObject.Find("Krampus").GetComponent<s_krampus>();
    }
    
    void Update()
    {
        //increment timer and change colour
        angle += Time.deltaTime;
        float offset = Mathf.Sin(angle * speed) * halfrange;
        float g = mid.g + offset;
        float b = mid.b + offset;
        Color temp = new Color(1, g, b, 1);
        this.GetComponent<SpriteRenderer>().color = temp;
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.name == "Player")
        {
            Manager.EnemyChosen = managerScript.EnemyType.krampus;
            Manager.ChooseEnemy();
            //Save the players return position
            _other.gameObject.GetComponent<control>().putMeBack = this.transform.position;
            //Change to battlemode
            Manager.battleOrOverworld = true;

            //Move player
            _other.transform.position = Manager.arenaLocation - 3.5f * Vector3.up;
            kramp.Active = true;
            Destroy(this.gameObject);
        }
    }
}

