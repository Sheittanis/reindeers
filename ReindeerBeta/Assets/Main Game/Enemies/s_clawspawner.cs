using UnityEngine;
using System.Collections;

public class s_clawspawner : MonoBehaviour
{
    //SPIKES//
    public float timer;
    public s_krampus Krampy;
    public Vector3 spawn_pos;

    public GameObject claw;
    // Use this for initialization
    void Start()
    {
        timer = 1.0f;
        Krampy = GameObject.Find("Krampus").GetComponent<s_krampus>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && Krampy.Active)
        {
            //random positions
            //chooses from a random (Area)
            //4 different areas, prevents from claws spawning on a certain area (on top of krampus)
            int choose = Random.Range(1, 4); //1 to 4
            Vector3 position1 = new Vector3(Random.Range(-60.0f, -40.0f), Random.Range(-8.5f, -3.5f), 0f);
            Vector3 position2 = new Vector3(Random.Range(-60.0f, -53.0f), Random.Range(-8.5f, 8.5f), 0f);
            Vector3 position3 = new Vector3(Random.Range(-47.0f, -40.0f), Random.Range(-8.5f, 8.5f), 0f);
            Vector3 position4 = new Vector3(Random.Range(-60.0f, -40.0f), Random.Range(3.5f, 8.5f), 0f);

            if (choose == 1)
            {
                Instantiate(claw, position1, Quaternion.identity);//spawn a claw ta position1 with default rotation.
            }
            if (choose == 2)
            {
                Instantiate(claw, position2, Quaternion.identity);
            }
            if (choose == 3)
            {
                Instantiate(claw, position3, Quaternion.identity);
            }
            if (choose == 4)
            {
                Instantiate(claw, position4, Quaternion.identity);
            }

            timer = 1.0f;
        }
    }
}
