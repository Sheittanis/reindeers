using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class blockme : MonoBehaviour {

    public bool blocked = false;
	
	void Update () {
	    if(blocked)
        {
            //Change button to dislpay error when blocked
            this.transform.GetChild(0).GetComponent<Text>().text = "<color=black>Nope</color>";
        }
        else
        {
            //Display regular button when not blocked
            this.transform.GetChild(0).GetComponent<Text>().text = "Play";
            this.transform.GetChild(0).GetComponent<Text>().color = new Color(1, 215.0f / 255.0f, 0, 1);
        }
	}
}
