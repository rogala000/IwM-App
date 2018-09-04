using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] Sprite musicOff;
    [SerializeField] Sprite musicOn;
    [SerializeField] Image soundImage;
    [SerializeField] GameObject infoPopup;
    [SerializeField] GameObject mainGame;

    private bool musicEnabled = true;

    private void OnEnable()
    {
        soundImage.sprite = musicOn;
    }


    public void ShowInfo()
    {
        AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.MenuPop);
        Instantiate(infoPopup);
    }

    public void ChangeMusic()
    {
        if(musicEnabled)
        {
            soundImage.sprite = musicOff;
            musicEnabled = false;
            AudioManager.instance.DisableSounds();
        }
        else
        {
            soundImage.sprite = musicOn;
            musicEnabled = true;
            AudioManager.instance.EnableSounds();
        }
    }


    public void ExitApp()
    {

        Debug.Log("Pew, exiting app. Doesn't work in the editor");
        Application.Quit();
    }

    public void StartGame()
    {
        AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.MenuPop);
        Instantiate(mainGame);
    }

}
