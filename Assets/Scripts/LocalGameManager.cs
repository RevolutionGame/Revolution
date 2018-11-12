using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour {

    private Player localPlayer;
    public Ship ship;
    public NetworkManager networkManager;
    private int localID;

    public NetworkPlayer[] NetworkPlayers = new NetworkPlayer[10];

    // Use this for initialization
    void Start () {
        localPlayer = new LocalPlayer();
        localPlayer.SpawnShip(Instantiate(ship,  new Vector3(0, 3), Quaternion.identity));
        AddNetworkPlayer(0);
        NetworkPlayers[0].SpawnShip(Instantiate(ship, new Vector3(3, 0), Quaternion.identity));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SendState();
        float[] location = new float[3];
        location[0] = System.Convert.ToSingle(networkManager.location[0].Trim('"'));
        location[1] = System.Convert.ToSingle(networkManager.location[1].Trim('"'));
        //location[2] = System.Convert.ToSingle(networkManager.location[2].Trim('"'));
        NetworkPlayers[0].Ship.GetComponent<Rigidbody2D>().transform.position = (new Vector3(location[0], location[1]));
        NetworkPlayers[0].Ship.GetComponent<Rigidbody2D>().rotation = location[2];
        Debug.Log("x: " + networkManager.location[0] + " y: " + networkManager.location[1]);
	}

    public void AddNetworkPlayer(int id) {
        NetworkPlayers[id] = new NetworkPlayer(id);
    }

    private void SendState() {
        //Debug.Log("character location: " + localPlayer.Ship.transform.position);
        networkManager.SendLocalTransform("0", this.localPlayer.Ship.transform);
    }

    private void UpdateFromNetwork (){
    }

    void StartGame() {        
        //this.localPlayer.SpawnShip(ship);
    }
}
