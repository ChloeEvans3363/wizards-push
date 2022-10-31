using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    public AudioClip music;

    public AudioSource m_MyAudioSource;

    //textures for toggle button
    public Texture2D soundOn;
    public Texture2D soundOff;
    Texture2D soundButton;

    //is sound enabled
    bool canPlay;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    float masterVolume;

    public void playConditional()
    {

        if (canPlay)
        {
            AudioClip sound = music;

            m_MyAudioSource.clip = music;

            m_MyAudioSource.loop = true;

            m_MyAudioSource.Play();

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

        //set default toggle image
        soundButton = soundOn;

        playConditional();

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
        canPlay = GUI.Toggle(new Rect(10, 0, Screen.width / 15, Screen.width / 15), canPlay, soundButton, "label");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            switch (canPlay)
            {
                case false:
                    soundButton = soundOff;
                    break;
                case true:
                    soundButton = soundOn;
                    break;
            }
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }
}