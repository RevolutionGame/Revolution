using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine;
using modelSpace;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviour{

    public class Player { public string email; public string pass; }

    public string[] location = new string[3];

    public SocketIOComponent socket;

    ApiManager apiManager = new ApiManager();

    public TMP_InputField password;
    public TMP_InputField mail;

    public UserData MainPlayer;
    LoginData ld;

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
        DontDestroyOnLoad(socket);
        StartCoroutine(ConnectToServer());
        socket.On("CONNECTION_SUCCESS", OnConnectionSuccess);
        socket.On("LOCATION_DATA", OnLocationData);
        //socket.On("GAME_START", OnGameStart);   
    }


    public void SendLocationData(string username, Transform transform)
    {

        Dictionary<string, string> data = new Dictionary<string, string>();
        string roomId = "room1";
        data["roomId"] = roomId;
        data["xCoord"] = transform.position.x.ToString();//x coordinate;
        data["yCoord"] = transform.position.y.ToString();//y coordinate;
        data["username"] = username;//name here;
        socket.Emit("LOCATION_DATA", new JSONObject(data));

    }

    private void OnLocationData(SocketIOEvent evt)
    {
        Debug.Log("packet colletcted");
        Debug.Log(evt.data.GetField("xCoord"));
        JSONObject theData = evt.data;
        //Debug.Log(evt.data.ToString());
        this.location[0] = evt.data.GetField("xCoord").ToString();
        this.location[1] = evt.data.GetField("yCoord").ToString();
        this.location[2] = evt.data.GetField("rotation").ToString();
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

    public void SendLocalTransform(string playerID, Transform transform)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        string roomId = "room1";
        data["roomId"] = roomId;
        data["xCoord"] = transform.position.x.ToString();
        data["yCoord"] = transform.position.y.ToString();
        data["rotation"] = transform.rotation.eulerAngles.z.ToString();
        data["username"] = playerID;
        socket.Emit("LOCATION_DATA", new JSONObject(data));
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

        MainPlayer.email = ld.data.email;
        
        Debug.Log("result is " + ld.data.name);

    }

    public LoginData Login()
    {
        int spin = 0;
        Coroutine status = null;

        status = StartCoroutine(login());

        while (status == null)
        {
            spin++;
            if(spin > 10000)
            {
                return ld;
            }
        }

        status = null;

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
}
