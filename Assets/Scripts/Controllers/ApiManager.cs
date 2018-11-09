using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager
{
    private Dictionary<string, string> reqObj = new Dictionary<string, string>();
    private string apiUrl = "https://revtest2018.herokuapp.com/v1";
    void Start()
    {
        //StartCoroutine(Upload());
    }

    /*
    IEnumerator Upload()
    {
        
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    */

    IEnumerator Login(string email,string pass){

        reqObj.Clear();

        reqObj.Add("email", email);
        reqObj.Add("pass", pass);

        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/player/login", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("login complete");
        }

    }

}