using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class LevelSelectManager : MonoBehaviour {
    void Update ()
    {
        //checks to see if there has been a mouse click or a touch input
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            RaycastHit hit;
            Ray ray;
            
            #if UNITY_EDITOR
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //for touch device
            #elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            #endif
            //if the raycast hits a collider with a number as its name it will load the level that corrisponds to that number as long as it's before or equal to the current day of the month  
            if (Physics.Raycast(ray, out hit))
            {
                //if beat level before ++ date is ok 
                                
                bool lvlB4 = PlayerPrefs.GetInt("levelsBeat") >= int.Parse(hit.collider.name) - 1;
                bool date = System.DateTime.Today.DayOfYear >= 335 + int.Parse(hit.collider.name);
                
                if (true)//lvlB4 && date)
                {
                    PlayerPrefs.SetInt("levelToPlay", int.Parse(hit.collider.name));
                    SceneManager.LoadScene("CharSelect");
                }
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
