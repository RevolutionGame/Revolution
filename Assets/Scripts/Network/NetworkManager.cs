using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using modelSpace;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

public class NetworkManager : MonoBehaviour{

    public SocketManager socketManager = new SocketManager();

    public static NetworkManager networkInstance;

    public static NetworkManager NetworkInstance
    {
        get { return networkInstance ?? (networkInstance = new GameObject("NetworkManager").AddComponent<NetworkManager>()); }
    }

    public class Player { public string email; public string pass; }


    ApiManager apiManager = new ApiManager();

    public TMP_InputField password;
    public TMP_InputField mail;

    public UserData MainPlayer;
    LoginData ld;

    public Text[] players = new Text[10];
    public string[] playerStatuses = new string[10];
    public Text lobbyStatus;
    private bool isReady = false;

    void Awake()
    {

        /*
        #region Enforce Sigelton Pattern on Network Manager and ensure its persistant
        if (NetworkInstance == null)
        {
                    NetworkInstance = this;
        }
        else if (NetworkInstance != this)
        {
                    Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        #endregion
        */
    }

    /* private static NetworkManager networkManager;

     private NetworkManager() { }

     public static NetworkManager getInstance()
     {
         if (networkManager == null)
             networkManager = new NetworkManager();
         return networkManager;
     }*/

    void Start()
    {
        DontDestroyOnLoad(this);
        //StartCoroutine(ConnectToServer());            
    }

    

    

    /*
    public void SendLocationData(JSONObject json)
    {
        socket.Emit("LOCATION_DATA", json);
    }

    private void OnLocationData(SocketIOEvent evt)
    {
        Debug.Log("packet colletcted");
        Debug.Log(evt.data.GetField("xCoord"));
        JSONObject theData = evt.data;
    }
    */

    /*
    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        string roomId = "room1";
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["roomId"] = roomId;
        //socket.Emit("USER_CONNECT", new JSONObject(data));

        yield return new WaitForSeconds(1f);
    }
    */

    /*
    private void OnConnectionSuccess(SocketIOEvent evt)
    {
        string roomId = evt.data.GetField("roomId").ToString().Replace("\"", "");
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["roomId"] = roomId;
        data["userId"] = "1";
        //Debug.Log("Room Info: " + evt.data);
        socket.Emit("ROOM_INFO", new JSONObject(data));      
    }
    
    private void OnForceGameStart(SocketIOEvent evt)
    {

        socket.Emit("GAME_FORCE_STARTED", evt.data);
        Debug.Log("Server says: " + evt.data);        
    }
    */

    public void UpdateWorldFromServer()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator login()
    {
        string email = mail.text;
        string pass = password.text;

        CoroutineWithData cd = new CoroutineWithData(this, apiManager.LoginUser(email, pass));
        yield return cd.coroutine;

        ld = (LoginData)cd.result;
        //LoginData ld = (LoginData)cd.result;

        MainPlayer.email = ld.data.email;
        
        Debug.Log("result is " + ld.data.name);

    }

    //Codys Stuff
    public static IEnumerator Login(string email, string password, Action onSuccess)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection($"email={email}&password={password}"));
        UnityWebRequest req = UnityWebRequest.Post("http://localhost:3000/login", formData);
        yield return req.SendWebRequest();
        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log("LOGIN: network or http error");
        }
        else
        {
            Debug.Log("LOGIN: Success");

        }
        onSuccess();
    }

    public void Logout()
    {
        throw new System.NotImplementedException();
    }

    public void EnterLobby()
    {
        throw new System.NotImplementedException();
    }
}
