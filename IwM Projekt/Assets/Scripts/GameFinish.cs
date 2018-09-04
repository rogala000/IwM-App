using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFinish : MonoBehaviour {

    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI summary;

    int score;
    float maxPoints;

	void Start () {
        score = GameManager.instance.Score;
        maxPoints = GameManager.instance.Questions.Count;
        result.text = score + "/" + maxPoints;

        if ((float) score < maxPoints * 0.5 )
        {
            summary.text = "Niestety tym razem sie nie udalo.";
        }
        else if ((float)score < maxPoints * 0.75)
        {
            summary.text = "Zdales. Gratuluje!";
        }
        else if ((float)score != maxPoints)
        {
            summary.text = "Dobrze Ci poszlo, zdales bez problemu";
        }
        else
        {
            summary.text = "Odpowiedziales poprawnie na wszystkie pytania!";
        }


    }


    public void Close()
    {
        AudioManager.instance.AudioSource.PlayOneShot(AudioManager.instance.MenuPop);
        Destroy(gameObject);
    }
}
