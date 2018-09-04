using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    [SerializeField] private AudioClip menuPop;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip correctAnswer;
    [SerializeField] private AudioClip wrongAnswer;


    public static AudioManager instance = null;
    private AudioSource audioSource;

    public AudioClip MenuPop
    {
        get
        {
            return menuPop;
        }

        set
        {
            menuPop = value;
        }
    }

    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }

        set
        {
            audioSource = value;
        }
    }

    public AudioClip CorrectAnswer
    {
        get
        {
            return correctAnswer;
        }

        set
        {
            correctAnswer = value;
        }
    }

    public AudioClip WrongAnswer
    {
        get
        {
            return wrongAnswer;
        }

        set
        {
            wrongAnswer = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void EnableSounds()
    {
        audioSource.enabled = true;
        musicSource.enabled = true;

    }

    public void DisableSounds()
    {
        audioSource.enabled = false;
        musicSource.enabled = false;

    }
}
