using UnityEngine;
using System.Collections;

public class s_Music : MonoBehaviour
{

    static bool AudioPlaying = false;
    public bool mute = false; //used for muting


    public AudioSource source;
    void Awake()
    {
        if (!AudioPlaying)
        {
            //plays the audiosource attached on launch
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioPlaying = true;
        }
    }

    public void VolumeUP()
    {
        source.volume += 0.1f; //volume control (same thing with volume button on the phone)

    }

    public void VolumeDOWN()
    {
        source.volume -= 0.1f; //volume control (same thing with volume button on the phone)

    }
    public void MuteMusic()
    {
        //mute the music button
        if (source.mute)//if true go to mute
        {
            source.mute = false; //mute
        }

        else //else unmute
        {
            source.mute = true; //unmutes
        }
    }

    public void backtomenu()
    {
        GameObject music = GameObject.Find("Music");
        GameObject OptionsCanvas = music.transform.GetChild(0).gameObject;
        //GameObject MainCanvas = GameObject.Find("MainCanvas");

        //MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void ads()
    {
        if (PlayerPrefs.GetInt("ads") == 0)
        {
            PlayerPrefs.SetInt("ads", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ads", 0);
        }
    }
}
