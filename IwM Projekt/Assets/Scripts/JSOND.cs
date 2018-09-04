using UnityEngine;
using LitJson;
using System;
using System.Collections;

public class parseJSON
{
    public string id;
    public string title;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public string correct;

}
public class JSOND : MonoBehaviour
{

    public void OnEnable()
    {
        StartCoroutine(Start());
    }

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        string url = "https://my-json-server.typicode.com/rogala000/IwMProjekt/questions";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Processjson(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    private void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        parseJSON parsejson;
        parsejson = new parseJSON();
        parsejson.title = jsonvale["title"].ToString();
        parsejson.id = jsonvale["id"].ToString();

        parsejson.answer1 = jsonvale["answer1"].ToString();
        parsejson.answer2 = jsonvale["answer2"].ToString();
        parsejson.answer3 = jsonvale["answer3"].ToString();
        parsejson.answer4 = jsonvale["answer4"].ToString();
        parsejson.correct = jsonvale["correct"].ToString();

        Debug.Log(parsejson);
    }
}


//using UnityEngine;
//using System.Collections;
//using System.Net;
//using System.Security.Cryptography.X509Certificates;
//using System.Net.Security;
//using System;

//public class JSOND : MonoBehaviour
//{
//    public string url = "https://my-json-server.typicode.com/rogala000/IwMProjekt/questions";
//    private string textFromWWW;

//    void Start()
//    {
//        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });

//        DownloadString(url);
//    }




//private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
//    {
//        //Return true if the server certificate is ok
//        if (sslPolicyErrors == SslPolicyErrors.None)
//            return true;

//        bool acceptCertificate = true;
//        string msg = "The server could not be validated for the following reason(s):\r\n";

//        //The server did not present a certificate
//        if ((sslPolicyErrors &
//             SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
//        {
//            msg = msg + "\r\n    -The server did not present a certificate.\r\n";
//            acceptCertificate = false;
//        }
//        else
//        {
//            //The certificate does not match the server name
//            if ((sslPolicyErrors &
//                 SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
//            {
//                msg = msg + "\r\n    -The certificate name does not match the authenticated name.\r\n";
//                acceptCertificate = false;
//            }

//            //There is some other problem with the certificate
//            if ((sslPolicyErrors &
//                 SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
//            {
//                foreach (X509ChainStatus item in chain.ChainStatus)
//                {
//                    if (item.Status != X509ChainStatusFlags.RevocationStatusUnknown &&
//                        item.Status != X509ChainStatusFlags.OfflineRevocation)
//                        break;

//                    if (item.Status != X509ChainStatusFlags.NoError)
//                    {
//                        msg = msg + "\r\n    -" + item.StatusInformation;
//                        acceptCertificate = false;
//                    }
//                }
//            }
//        }

//        //If Validation failed, present message box
//        if (acceptCertificate == false)
//        {
//            msg = msg + "\r\nDo you wish to override the security check?";
//            //          if (MessageBox.Show(msg, "Security Alert: Server could not be validated",
//            //                       MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
//            acceptCertificate = true;
//        }

//        return acceptCertificate;
//    }


//    public static void DownloadString(string address)
//    {
//        WebClient client = new WebClient();
//        string reply = client.DownloadString(address);

//        Debug.Log(reply);
//    }


//}