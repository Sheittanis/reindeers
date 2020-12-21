using UnityEngine;
using System.Collections;

public class snowman : MonoBehaviour {

    public GameObject snowball;
    float timer = 0.0f;
    float interval = 2.5f;
    int direction = 0;
    Vector3[] directions = { Vector3.right, Vector3.up, -Vector3.right, -Vector3.up };

	void Update () {
        //increment timer
        timer += Time.deltaTime;
        //when timer reached
        if(timer >= interval)
        {
            //spawn snowball in direction
            GameObject current = Instantiate(snowball, this.transform.position + directions[direction] * 1.5f, Quaternion.identity) as GameObject;
            current.GetComponent<snowball>().direction = directions[direction];
            //change direction for next snowball
            direction++;
            if (direction == 4)
            {
                direction = 0;
            }
            timer = 0;
        }

	}
}
