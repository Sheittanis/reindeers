using UnityEngine;
using System.Collections;

public class gingerbread : MonoBehaviour {
    //Manager for checking whether in battle or overworld for movement functions
    managerScript Manager;


    float angle = 0.0f;
    float speed = 1.5f;
    float halfrange = -1.0f;

    //battleMode;
    public s_gingerman sGinger;

    void Start()
    {
        //get manager and battle mode
        Manager = GameObject.Find("Manager").GetComponent<managerScript>();
        sGinger = GameObject.Find("gingerman").GetComponent<s_gingerman>();
    }
    
    void Update()
    {
        //increment timer, do movement
        angle += Time.deltaTime;
        float offset = Mathf.Sin(angle * speed) * halfrange;
        this.transform.rotation = Quaternion.Euler(Vector3.forward * offset * 45);
    }

    void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.name == "Player")
        {
            Manager.EnemyChosen = managerScript.EnemyType.gingerman;
            Manager.ChooseEnemy();

            //Save the players return position
            _other.gameObject.GetComponent<control>().putMeBack = this.transform.position;

            //Change to battlemode
            Manager.battleOrOverworld = true;
            _other.transform.position = Manager.arenaLocation - 1.5f * Vector3.up;
            sGinger.Active = true;

            Destroy(this.gameObject);
        }
    }
}