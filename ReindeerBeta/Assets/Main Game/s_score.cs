using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class s_score : MonoBehaviour
{
    //score check
    public float timer = 0.0f;
    public int score = 100;
    public int finalScore = 0;

    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        //default for each level
        score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //counts down along with the timer
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            score--;
            timer = 1.0f;
            scoreText.text = "Score: " + score; //updates the onscreen text

        }

        if (score < 0)
        {
            score = 0; //reaching 0 DOES NOT kill you. Just makes your score suck more. 
            //can be changed to actually kill the player
            //game is already hard, might as well let the player finish if they are bad on the timer and get no score
            //they can "pump" their score up by finishing battle arenas
        }


    }

    public int endScore()
    {

        //onlevel end
        finalScore = score;
        score = 100;//resets it
        return finalScore;
    }

}
