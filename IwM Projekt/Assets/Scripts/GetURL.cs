using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LitJson;
using UnityEngine;
using UnityEngine.Networking;


//public class QuestionsJSON{
//    public List<QuestionJSON> questions;
//}

public class QuestionJSON
{
    public int id;
    public string title;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public string correct;

}

public class GetURL : MonoBehaviour {

    string url = "https://my-json-server.typicode.com/rogala000/IwMProjekt/questions";
    string Json;
    public List<QuestionJSON> questions = new List<QuestionJSON>();

    public static GetURL instance = null;

    private void Awake()
    {
        if(instance == null)
        { instance = this; }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }


    void Start () {
            questions.Clear();
            StartCoroutine(GetText(url));

        }


    IEnumerator GetText(string url)
    {
    int questionsNumber = 10;
    for (int i = 1; i <= questionsNumber; i++)
        {

            if(i==5)
            { EventManager.TriggerEvent("HalfTime"); }
            string query = "?id=" + i;
            string fullURL = url + query;

            UnityWebRequest www = UnityWebRequest.Get(fullURL);
            yield return www.SendWebRequest();


            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {


                // Show results as text
                string result = www.downloadHandler.text;
                string replacement = Regex.Replace(result, @"\t|\n|\r", "");
                replacement = replacement.Replace("\\", String.Empty);
                replacement = replacement.Replace("[", String.Empty);
                replacement = replacement.Replace("]", String.Empty);



                Debug.Log(replacement);
                Processjson(replacement);
            }


        }
        EventManager.TriggerEvent("Start");
        GameManager.instance.GetQuestions();
        Debug.Log(questions.ToString());
    }



    private void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        QuestionJSON parsejson;
        parsejson = new QuestionJSON();

        parsejson.title = jsonvale["title"].ToString();
        parsejson.id = Int32.Parse(jsonvale["id"].ToString());
        parsejson.answer1 = jsonvale["answer1"].ToString();
        parsejson.answer2 = jsonvale["answer2"].ToString();
        parsejson.answer3 = jsonvale["answer3"].ToString();
        parsejson.answer4 = jsonvale["answer4"].ToString();
        parsejson.correct = jsonvale["correct"].ToString();

        questions.Add(parsejson);
        }

    

}
