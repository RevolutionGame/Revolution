using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using SocketIO;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    public class Player { public string email; public string pass; }

    public string[] location = new string[2];

    public SocketIOComponent socket;

    // Use this for initialization
    void Start()
    {
        location[0] = "0";
        location[1] = "0";
        DontDestroyOnLoad(socket);
        StartCoroutine(ConnectToServer());
        socket.On("CONNECTION_SUCCESS", OnConnectionSuccess);
        socket.On("LOCATION_DATA", onLocationData);
        socket.On("GAME_START", OnGameStart);
        socket.On("TEST_DATA", onTestData);


        //myWebTest();

        // StartCoroutine(myWebTest());




    }


    //private IEnumerator myWebTest()
    //{
    //    var myObject = new Player { email = "cs9stephen@gmail2.com", pass = "showmetheway" };
    //    string jsonStringTrial = JsonUtility.ToJson(myObject);

    //    UnityWebRequest www = UnityWebRequest.Post("https://revtest2018.herokuapp.com/v1/player/login", jsonStringTrial);
    //    www.SetRequestHeader("Accept", "application/json");
    //    UnityWebRequestAsyncOperation r = www.SendWebRequest();
    //    yield return www.SendWebRequest();


    //}


    public void sendLocationData(string username, float x, float y)
    {

        Dictionary<string, string> data = new Dictionary<string, string>();
        string roomId = "room1";
        data["roomId"] = roomId;
        data["xCoord"] = x.ToString();//x coordinate;
        data["yCoord"] = y.ToString();//y coordinate;
        data["username"] = username;//name here;
        socket.Emit("LOCATION_DATA", new JSONObject(data));

    }

    private void onLocationData(SocketIOEvent evt)
    {
        Debug.Log("packet colletcted");
        Debug.Log(evt.data.GetField("xCoord"));
        JSONObject theData = evt.data;
        //Debug.Log(evt.data.ToString());
        this.location[0] = evt.data.GetField("xCoord").ToString();
        this.location[1] = evt.data.GetField("yCoord").ToString();
        //Debug.Log("Got from server { x: " + this.location[0] + " y: " + this.location[1] + " }");
        //update ships accordingly
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
        socket.Emit("TEST_DATA", new JSONObject(data));
        // SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
    }

    private void onTestData(SocketIOEvent evt)
    {
        Debug.Log("Test data: " + evt.data);
    }

    private void OnGameStart(SocketIOEvent evt)
    {
        Debug.Log("Server says: " + evt.data);
        //code to start the new scene
    }

    // Update is called once per frame
    void Update()
    {

    }


}
