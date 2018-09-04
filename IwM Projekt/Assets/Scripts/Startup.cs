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


    private UnityAction someListener;

    void Awake()
    {
        someListener = new UnityAction(LoadMainScene);
    }

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        EventManager.StartListening("Start", someListener);
        StartCoroutine(StartGame());
	}

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        text.text = "Jaroslaw Rogalski";
        audioSource.PlayOneShot(pop);

    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

}
