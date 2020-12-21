using UnityEngine;
using System.Collections;

public class snowball : MonoBehaviour {
    public Vector3 direction;
	
    //Move snowball in direction
	void Update () {
        transform.Translate(direction * Time.deltaTime * 2.0f);
	}

    //destroy this on collision, damage if hit player
    public void OnCollisionEnter2D(Collision2D Col)
    {
            if (Col.gameObject.name == "Player")
            {
                Col.gameObject.GetComponent<control>().damageMe(0.75f);
            }

            Destroy(gameObject);
        
    }
}
