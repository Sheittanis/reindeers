using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public bool inGame = false;
    bool eneteredGame = false;
    public bool dead = false;
    public AudioClip[] songs;
    bool kd;
    public AudioClip COTBStart;
    public AudioClip COTBLoop;
    public AudioClip COTBEnd;
    public AudioClip menu;

    int unlocked;

    AudioSource output;

    int lastPlayed;

    void Start()
    {
        int maxlvl = PlayerPrefs.GetInt("levelsBeat");

        //increase number of songs unlocked with levels beaten
        unlocked = (maxlvl / 3) + 3;

        //limit to 9 songs
        if (unlocked > 9)
        {
            unlocked = 9;
        }

        output = this.GetComponent<AudioSource>();


    }


    void Update()
    {
        //if in game
        if (inGame)
        {
            //When dead
            if(dead && output.clip != COTBEnd)
            {
                output.Stop();
                output.clip = COTBEnd;
                output.Play();

            }

            //lvl 25
            else if (PlayerPrefs.GetInt("levelToPlay") == 25)
            {
                if (output.clip == menu)
                {
                    output.clip = COTBStart;
                    output.Play();
                }

                if (!output.isPlaying && output.clip != COTBEnd)
                {
                    output.clip = COTBLoop;
                    output.Play();
                }

                if(kd)
                {
                    output.clip = COTBEnd;
                    output.Play();
                    kd = false;
                }
            }

            //other levels
            else
            {
                //If we have just entered cut menu music and start new music
                if (!eneteredGame)
                {
                    lastPlayed = Random.Range(0, unlocked);
                    output.clip = songs[lastPlayed];
                    output.Play();
                    eneteredGame = true;
                }
                else
                {
                    if (!output.isPlaying || output.clip == menu)
                    {
                        int rand = Random.Range(0, unlocked);
                        while (rand == lastPlayed)
                        {
                            rand = Random.Range(0, unlocked);
                        }
                        lastPlayed = rand;
                        output.clip = songs[rand];
                        output.Play();
                    }
                }
            }
        }
        //If still in menu keep looping menu song
        else
        {
            if (!output.isPlaying || output.clip != menu)
            {
                output.clip = menu;
                output.Play();
            }
        }
    }

    public void krampusdead()
    {
        kd = true;
    }
}
