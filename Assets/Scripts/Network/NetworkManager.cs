using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine;
using modelSpace;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviour{

    public class Player { public string email; public string pass; }

    public SocketIOComponent socket;

    ApiManager apiManager = new ApiManager();

    public TMP_InputField password;
    public TMP_InputField mail;

    public UserData MainPlayer;

    private JSONObject worldJSON;

    public JSONObject WorldJSON
    {
        get{ return worldJSON; }
        set{ worldJSON = value; }
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
        DontDestroyOnLoad(socket);
        StartCoroutine(ConnectToServer());            
    }


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

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        string roomId = "room1";
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["roomId"] = roomId;
        socket.Emit("USER_CONNECT", new JSONObject(data));

        yield return new WaitForSeconds(1f);
    }

    private void OnConnectionSuccess(SocketIOEvent evt)
    {
        string roomId = "room1";
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["roomId"] = roomId;
        Debug.Log("Room Info: " + evt.data);
        socket.Emit("ROOM_INFO", new JSONObject(data));      
    }

    private void OnGameStart(SocketIOEvent evt)
    {
        Debug.Log("Server says: " + evt.data);        
    }

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
        LoginData ld = (LoginData)cd.result;

        MainPlayer.email = ld.data.email;
        

        Debug.Log("result is " + ld.data.name);

    }

    public void Login()
    {
        
        StartCoroutine(login());

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
