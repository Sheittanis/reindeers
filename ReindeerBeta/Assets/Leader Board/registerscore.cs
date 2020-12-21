using UnityEngine;
using System.Collections;

public class registerscore : MonoBehaviour {
    
    public button database;
    public GameObject databasebutton;
    
	void Start () {        
        database.display();
        databasebutton.SetActive(true);
    }

    public void registerPress()
    {
        database.OnButtonClick();
        databasebutton.SetActive(false);
    }
}
