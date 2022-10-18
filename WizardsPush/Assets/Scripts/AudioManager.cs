using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip targetDown;
    public AudioClip targetUp;
    public AudioClip pushSpell;
    public AudioClip pullSpell;
    public AudioClip walkPush;

    public AudioSource m_MyAudioSource;

    //is sound enabled
    bool canPlay;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    float masterVolume;

    public void playConditional(int clipIndex, bool looped)
    {
       
        if (canPlay)
        {
            AudioClip sound = null;
            
            switch (clipIndex)
            {
                case 1:
                    sound = targetDown;
                        break;
                case 2:
                    sound = targetUp;
                        break;
                case 3:
                    sound = pushSpell;
                        break;
                case 4:
                    sound = pullSpell;
                        break;
                case 5:
                    sound = walkPush;
                        break;
            }

            switch (looped)
            {
                case true:
                    m_MyAudioSource.loop = false;
                    m_MyAudioSource.PlayOneShot(sound, masterVolume);
                    break;

                case false:
                    m_MyAudioSource.loop = true;
                    m_MyAudioSource.PlayOneShot(sound);
                    break;
            }
        }
    }

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        canPlay = true;
        masterVolume = 0.7f;
        m_MyAudioSource.volume = masterVolume;
    }

    void Update()
    {
       
        //Check if you just set the toggle to false
        if (canPlay == false && m_ToggleChange == true)
        {
            //Stop the audio
            m_MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        canPlay = GUI.Toggle(new Rect(10, 10, 100, 30), canPlay, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }
}