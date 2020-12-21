using UnityEngine;
using System.Collections;

public class s_buff : MonoBehaviour
{
    public float timer = 3.0f;
    public s_score score;

    // Update is called once per frame
    void Start()
    {
        timer = 3.0f;
        score = GameObject.Find("Manager").GetComponent<s_score>();
    }

    void Update()
    {
        //buffs only stay active for a certain amount of time
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            despawnBuff();
            timer = 3.0f;
        }
    }

    public void despawnBuff()
    {
        //despawn the buff
        Destroy(this.gameObject);

    }
    void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.name == "Player")
        {
            _other.GetComponent<control>().healMe(0.3f); //heals the player

            score.score = score.score + 7; //increase the score for each buff picked up
                                           // gameObject.GetComponent<s_score>().score = gameObject.GetComponent<s_score>().score + 10 ;

            Destroy(this.gameObject);
        }
    }

}
