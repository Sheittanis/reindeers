using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    float timer = 31.2f;
    float time = 0.0f;

	float countdonwn;
	Vector2 spawnHere;
	public float baseTime;
	public float timerLeeWay;
	public GameObject thing2Spawn;
	public bool relativeSpawnPos;
	public bool square;
	public Vector2 bottomLeft;
	public Vector2 topRight;
	public bool circle;
	public Vector2 centre;
	public float radius;
	public bool randomiseColour;

    public GameObject head1;
    public GameObject head2;
    public GameObject head3;
    public GameObject head4;
    public GameObject head5;
    public GameObject head6;
    public GameObject head7;
    public GameObject head8;
    public GameObject head9;
    public GameObject rudolphbody;
    public GameObject startgame;
    public GameObject optionbutton;
    
    void Start () {

        if (PlayerPrefs.GetInt("PlayedGameCheck") == 0)
        {
            intro();
        }
        else
        {
            startgame.SetActive(true);
            optionbutton.SetActive(true);
            optionbutton.transform.GetChild(0).gameObject.SetActive(true);
            intro();
        }

		if (!square && !circle) {
			print ("Spawner has not been set to square or circle");
		}
		ResetTimer ();

        GameObject.Find("Music").GetComponent<musicManager>().inGame = false;
    }

	void Update () {
        intro();
        time += Time.deltaTime;
        countdonwn -= Time.deltaTime;
		if (countdonwn <= 0) {
			if(square){
				spawnHere.x = Random.Range(bottomLeft.x, topRight.x);
				spawnHere.y = Random.Range(bottomLeft.y, topRight.y);
			}
			if(circle){
				spawnHere = Random.insideUnitCircle * radius + centre;
			}
			if(relativeSpawnPos){
				spawnHere += new Vector2(this.transform.position.x, this.transform.position.y);
			}
			GameObject _flake = Instantiate(thing2Spawn, spawnHere, Quaternion.identity) as GameObject;
            randomiseColour = (time >= timer);
			if(randomiseColour){
				baseTime = 0.05f;
				timerLeeWay = 0.01f;
				Vector3 _rgb = Random.insideUnitSphere + Vector3.one / 4.0f;
				_flake.GetComponent<SpriteRenderer>().color = new Color(_rgb.x, _rgb.y, _rgb.z, 1.0f); 
			}
			ResetTimer();
		}



        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


	}

	void ResetTimer() {
		countdonwn = baseTime + Random.Range (-timerLeeWay, timerLeeWay);
	}

    void intro()
    {
        if(time >=31.2f)
        {
            startgame.SetActive(true);
            optionbutton.SetActive(true);
            optionbutton.transform.GetChild(0).gameObject.SetActive(true);
            rudolphbody.SetActive(true);
            head9.SetActive(true);
        }
        else if (time >= 18.2f)
        {
            head8.SetActive(true);
        }
        else if (time >= 17.0f)
        {
            head7.SetActive(true);
        }
        else if (time >= 15.8f)
        {
            head6.SetActive(true);
        }
        else if (time >= 14.6f)
        {
            head5.SetActive(true);
        }
        else if (time >= 13.4f)
        {
            head4.SetActive(true);
        }
        else if (time >= 12.2f)
        {
            head3.SetActive(true);
        }
        else if (time >= 11.0f)
        {
            head2.SetActive(true);
        }
        else if (time >= 9.8f)
        {
            head1.SetActive(true);
        }
        
    }
}
