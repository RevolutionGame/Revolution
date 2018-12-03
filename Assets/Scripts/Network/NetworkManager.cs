using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;
using modelSpace;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviour{

    public class Player { public string email; public string pass; }

    public string[] location = new string[3];      

    ApiManager apiManager = new ApiManager();

    public TMP_InputField password;
    public TMP_InputField mail;

    public UserData MainPlayer;
    LoginData ld;
    public SocketManager socketManager = new SocketManager("ws://localhost:8080/lobby");
    
    /*
    private JSONObject worldJSON;

    public JSONObject WorldJSON
    {
        get{ return worldJSON; }
        set{ worldJSON = value; }
    }
    */

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
        location[0] = "0";
        location[1] = "0";
       // location[2] = "0";        
        //StartCoroutine(ConnectToServer());
        //socket.On("CONNECTION_SUCCESS", OnConnectionSuccess);
        //socket.On("LOCATION_DATA", OnLocationData);
        //socket.On("GAME_START", OnGameStart);   
        socketManager.ConnectToSocket();
    }

    public void SendLocationData(string username, Transform transform)
    {

        Dictionary<string, string> data = new Dictionary<string, string>();
        string roomId = "room1";
        data["roomId"] = roomId;
        data["xCoord"] = transform.position.x.ToString();//x coordinate;
        data["yCoord"] = transform.position.y.ToString();//y coordinate;
        data["username"] = username;//name here;        

    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        string roomId = "room1";
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["roomId"] = roomId;        

        yield return new WaitForSeconds(1f);
    }

    public void SendLocalTransform(string playerID, Transform transform)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        string roomId = "room1";
        data["roomId"] = roomId;
        data["xCoord"] = transform.position.x.ToString();
        data["yCoord"] = transform.position.y.ToString();
        data["rotation"] = transform.rotation.eulerAngles.z.ToString();
        data["username"] = playerID;        
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

        ld = (LoginData)cd.result;
        //LoginData ld = (LoginData)cd.result;

        MainPlayer.email = ld.data.email;
        
        Debug.Log("result is " + ld.data.name);

    }

    public LoginData Login()
    {
        
       StartCoroutine(login());

        return ld;

    }

    public void Logout()
    {
        throw new System.NotImplementedException();
    }

    public void EnterLobby()
    {
        throw new System.NotImplementedException();
    }

    public void SendReady()
    {
        socketManager.SendReady();
    }
}
