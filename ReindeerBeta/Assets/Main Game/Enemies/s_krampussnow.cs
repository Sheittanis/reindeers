using UnityEngine;
using System.Collections;

public class s_krampussnow : MonoBehaviour
{

    public GameObject snowball;
    public s_krampus Krampy;
    float timer = 0.0f;

    float interval = 0.05f;

    int direction = 0;

    Vector3[] directions = { Vector3.right, Vector3.up, -Vector3.right, -Vector3.up };

    void Start()
    {
        Krampy = GameObject.Find("Krampus").GetComponent<s_krampus>();
    }
    void Update()
    {
        //activity timer
        //increment timer
        timer += Time.deltaTime;
        if (timer >= interval && Krampy.Active)
        {
            //Spawn snowball and move it in direction
            GameObject current = Instantiate(snowball, this.transform.position + directions[direction] * 1.5f, this.transform.rotation) as GameObject;
            current.GetComponent<s_krampusballs>().direction = directions[direction];

            //Change direction for next snowball
            direction++;
            if (direction == 4)
            {
                direction = 0;
            }

            //reset timer
            timer = 0;
        }
        transform.Rotate(0, 0, 1.0f);

    }


}
