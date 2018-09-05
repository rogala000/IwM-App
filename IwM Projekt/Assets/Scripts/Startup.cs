using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startup : MonoBehaviour {

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] AudioClip pop;
    [SerializeField] GameObject noInternetPopup;

    private UnityAction someListener;
    bool connectionOK = true;

    void Awake()
    {
        someListener = new UnityAction(LoadMainScene);

    }

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        EventManager.StartListening("Start", someListener);
        EventManager.StartListening("HalfTime", HalfTime);
        EventManager.StartListening("NoInternet", NoInternet);
        EventManager.StartListening("InternetOK", InternetOK);
	}

    void HalfTime()
    {
        text.text = "Jaroslaw Rogalski";
        audioSource.PlayOneShot(pop);

    }




    void LoadMainScene()
    {
        if (connectionOK)
        {
            audioSource.PlayOneShot(pop);
            SceneManager.LoadScene("Main");
        }
        
    }


    public void RestartApp(){
        GetURL.instance.enabled = false;
        GetURL.instance.enabled = true;
        SceneManager.LoadScene("Startup");
    }

    public void NoInternet(){
        Debug.Log("No internet handled");
        connectionOK = false;
        Instantiate(noInternetPopup);
    }

    public void InternetOK(){
        connectionOK = true;
    }

}
