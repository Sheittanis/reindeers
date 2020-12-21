using UnityEngine;
using System.Collections;

public class s_levelBeat : MonoBehaviour
{

    public SpriteRenderer lvlCompleted;
    public Sprite Complete;
    // Use this for initialization
    void Start()
    {
        lvlCompleted = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the name of this object (the level it is for) as an int
        int result;
        int.TryParse(this.name, out result);

        //If we have beat a level at least as big as this level
        if (PlayerPrefs.GetInt("levelsBeat") >= result)
        {
            //changes the sprite of the gift to the "complete" version
            lvlCompleted.sprite = Complete;
        }
    }
}
