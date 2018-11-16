using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine;

public class NetworkManager : MonoBehaviour{

    public class Player { public string email; public string pass; }

    public string[] location = new string[3];

    public SocketIOComponent socket;
        
    void Start()
    {
        location[0] = "0";
        location[1] = "0";
        //location[2] = "0";
        DontDestroyOnLoad(socket);
        StartCoroutine(ConnectToServer());
        socket.On("CONNECTION_SUCCESS", OnConnectionSuccess);
        socket.On("LOCATION_DATA", OnLocationData);
        socket.On("GAME_START", OnGameStart);        
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

    public void Login()
    {
        throw new System.NotImplementedException();
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
