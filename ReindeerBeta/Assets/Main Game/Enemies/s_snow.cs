using UnityEngine;
using System.Collections;

public class s_snow : MonoBehaviour
{
    public float timer;

    // Use this for initialization
    void Start()
    {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //destroy the balls in a timer
            destruction();
        }
    }

    public void destruction()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Player" || Col.gameObject.tag == "Boundary") //destroyed if it touches the boundaries
        {
            Destroy(gameObject);
            Col.gameObject.GetComponent<control>().damageMe(1.0f); //1 damage per snow
            //The current max health is 5 so maybe most things should do somewhere between 0.25 and 1 damage

        }
        else
        {
            Destroy(gameObject);
        }

    }
}
