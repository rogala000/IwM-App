using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour {

public void Close()
    {
        AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.MenuPop);
        Destroy(gameObject);
    }
}
