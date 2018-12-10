using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using modelSpace;



    public class ApiManager : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {
            ApiManager apiManager = new ApiManager();

  

            
           // int x = 0;

        }


        private Dictionary<string, string> reqObj = new Dictionary<string, string>();
        private string apiUrl = "https://revtest2018.herokuapp.com/v1";
   

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

    public IEnumerator LoginWrapper(string email, string pass)
    {

        CoroutineWithData cd = new CoroutineWithData(this, LoginUser(email,pass));
        yield return cd.coroutine;
        LoginData ld = (LoginData) cd.result;

        Debug.Log("result is " + ld.data.name);

    }



    public IEnumerator LoginUser(string email, string pass)
    {

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
            Debug.Log(www.downloadHandler.text);

            LoginData loadedData = JsonUtility.FromJson<LoginData>(www.downloadHandler.text);
            yield return loadedData;

        
            Debug.Log("login complete");
            }

       }

    public IEnumerator CreateUser(string email, string fullName, string username, string playerCellNumber, string pass)
    {

        reqObj.Clear();

        reqObj.Add("email", email);
        reqObj.Add("fullName", fullName);
        reqObj.Add("username", username);
        reqObj.Add("playerCellNumber", playerCellNumber);
        reqObj.Add("pass", pass);

        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/player/create", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

                CreateUserData createUserData = JsonUtility.FromJson<CreateUserData>(www.downloadHandler.text);

            yield return createUserData;


            Debug.Log("created user");
        }

    }

    public IEnumerator GetScoreBoard() {

        //returns an array of scores with player info inside

        reqObj.Clear();

        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/scores/player/get", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log(www.downloadHandler.text);

            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(www.downloadHandler.text);

            yield return scoreData;


        }

    }


    public IEnumerator GetPlayerScore(int playerId)
    {


        //use player id to get score


        reqObj.Clear();

        reqObj.Add("id", playerId.ToString());
     

        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/scores/player/get", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(www.downloadHandler.text);

            yield return scoreData;


            Debug.Log("created user");
        }

    }

    public IEnumerator AddPlayerScore(string email, int score)
    {


        //use player id to get score


        reqObj.Clear();

        reqObj.Add("email", email);
        reqObj.Add("score", score.ToString());


        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/player/addScore", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(www.downloadHandler.text);

            yield return scoreData;


            Debug.Log("created user");
        }

    }


    public IEnumerator UpdatePlayerField(string field,string value,string playeremail)
    {

        //fields match the fields in UserData e.g(name,username,email,shiptype,weapontype)

        reqObj.Clear();

        reqObj.Add("field", field);
        reqObj.Add("value", value);
        reqObj.Add("email", playeremail);


        UnityWebRequest www = UnityWebRequest.Post(apiUrl + "/player/update", reqObj);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            MsgData msgData = JsonUtility.FromJson<MsgData>(www.downloadHandler.text);

            yield return msgData;


            Debug.Log(msgData.msg);
        }

    }

}   

