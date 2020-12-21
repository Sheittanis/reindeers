using UnityEngine;
using System.Collections;

public class s_spawnSnow : MonoBehaviour
{

    public float timer;
    public GameObject pengu;
    public GameObject snow; //prefab it

    public float snowCounter = 1;
    public Vector3 spawn_pos;

    public s_pengu spenguin;

    // Use this for initialization
    void Start()
    {
        timer = 3.0f; //reset the arena timer
        spenguin = GameObject.Find("Penguin").GetComponent<s_pengu>();

    }

    // Update is called once per frame
    public void Update()
    {
        //activity timer
        timer -= Time.deltaTime;
        if (timer < 0 && spenguin.Active)
        {

            //spawn below the penguin
            spawn_pos.y = pengu.transform.position.y - 2.0f;
            spawn_pos.x = pengu.transform.position.x;
            Instantiate(snow, spawn_pos, Quaternion.identity);
            timer = 3 - (snowCounter * 0.1f); //makes spawn timer lower as the arena goes on
            snowCounter++; //more snow = makes it faster
        }

        if (spenguin.Active == false)
        {
            timer = 3.0f;
            snowCounter = 1.0f;
        }
    }
}
