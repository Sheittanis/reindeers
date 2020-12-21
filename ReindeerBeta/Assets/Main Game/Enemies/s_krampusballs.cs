using UnityEngine;
using System.Collections;

public class s_krampusballs : MonoBehaviour
{
    public Vector3 direction;

    //all of krampus' balls!

    // Update is called once per frame
    void Update()
    {
        //direction they shoot out at and their speed
        transform.Translate(direction * Time.deltaTime * 5.0f);
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.name == "Player")
        {
            Col.gameObject.GetComponent<control>().damageMe(0.75f); //each ball damages the player
        }
        //they get destroyed if they collide with anything. Claw, border or player, only damage the player 
        Destroy(gameObject);

    }
}
