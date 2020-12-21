using UnityEngine;
using System.Collections;

public class s_claw : MonoBehaviour
{
    //*spike*//
    //timers
    public float timer;
    public float delay;
    public float destroy_timer;
    // Use this for initialization
    void Start()
    {
        timer = 1.0f;
        destroy_timer = 2.5f;
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        destroy_timer -= Time.deltaTime;
        if (timer < 0)
        {
            delay++;//delays the claw activity so it doesnt kill you when it spawns
            timer = 1.0f;
        }

        //countdown to autodestroy
        if (destroy_timer < 0)
        {
            slash();
        }
    }

    public void slash()
    {
        //destroy the gameobject
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Player" && delay >= 2) //checks for the player and if the claw is active)
        {
            Destroy(gameObject);
            Col.gameObject.GetComponent<control>().damageMe(2.5f); //damage the player for 2.5hp

        }

    }
}
