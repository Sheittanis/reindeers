using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class credit : MonoBehaviour {
    float time = 0;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time >= 5.0f)
        {
            SceneManager.LoadScene("Main Menu");
        }
	}
}
