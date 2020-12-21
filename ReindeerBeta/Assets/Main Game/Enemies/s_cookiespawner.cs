using UnityEngine;
using System.Collections;

public class s_cookiespawner : MonoBehaviour
{

    public float timer;
    public GameObject cookie; //prefab it

    public s_gingerman sGinger;

    // Use this for initialization
    void Start()
    {
        timer = 2.0f;
        sGinger = GameObject.Find("gingerman").GetComponent<s_gingerman>();
    }

    // Update is called once per frame
    public void Update()
    {
        //timer (countdown)
        timer -= Time.deltaTime;
        if (timer < 0 && sGinger.Active) //checks if the gingerbread arena is active
        {
            //random range
            Vector3 position = new Vector3(Random.Range(-31.0f, -19.0f), Random.Range(22.5f, 16.0f), 0f);
            //spawn the cookie (buff)
            Instantiate(cookie, position, Quaternion.identity);
            timer = 1.0f;
        }
    }
}
