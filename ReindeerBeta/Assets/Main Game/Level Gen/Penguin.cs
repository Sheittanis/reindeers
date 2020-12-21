using UnityEngine;
using System.Collections;

public class Penguin : MonoBehaviour {
    //Manager for checking whether in battle or overworld for movement functions
    managerScript Manager;

    Vector3 origin;
    float angle = 0.0f;
    float speed = 1.5f;
    float halfrange = -2.0f;

    //battleMode
    public s_pengu sPengu;

    void Start()
    {
        origin = this.transform.position;
        //get manager and battle mode
        Manager = GameObject.Find("Manager").GetComponent<managerScript>();
        sPengu = GameObject.Find("Penguin").GetComponent<s_pengu>();
    }
    
    void Update()
    {
        //increment timer and do movement
        angle += Time.deltaTime;
        float offset = Mathf.Sin(angle * speed) * halfrange;
        this.transform.position = origin + Vector3.right * offset;
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.name == "Player")
        {
            Manager.EnemyChosen = managerScript.EnemyType.penguin;
            Manager.ChooseEnemy();

            //Save the players return position
            _other.gameObject.GetComponent<control>().putMeBack = this.transform.position;


            //Change to battlemode
            Manager.battleOrOverworld = true;

            //Move player
            _other.transform.position = Manager.arenaLocation - 1.5f * Vector3.up;
            sPengu.Active = true;


            Destroy(this.gameObject);
        }
    }
}
