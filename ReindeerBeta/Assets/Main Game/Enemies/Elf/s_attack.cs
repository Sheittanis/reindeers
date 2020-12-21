using UnityEngine;
using System.Collections;

public class s_attack : MonoBehaviour
{
    //Size
    public float size = 0; //variable thats used to identify if the gift is large enough to deal damage
    //public float min_Size = 1;
    //public float max_Size = 5;

    //timers
    public float timer = 0.0f;
    public float explosion_timer = 5.0f;

    public void Update()
    {
        //Countdown, makes the gift larger
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            growth();
            size++;
        }


        if (size == 5)
        {
            //when the gift reaches a certain size, explode it
            explosion();
        }

    }

    public void growth()
    {
        //enlarges the gift
        transform.localScale += new Vector3(0.5f, 0.5f, 0);
        timer = 1.0f;
    }

    public void explosion()
    {
        Destroy(gameObject); //destroys the gameobject
    }

    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player" && size >= 3) //Checks if the colliding object is the player AND the size of the gift
        {
            //damages the player for 3.0hp
            _other.GetComponent<control>().damageMe(3.0f);
        }
    }

}
