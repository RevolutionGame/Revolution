using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour {

    private Player localPlayer;
    public Ship ship;
    public NetworkManager networkManager;

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
        float[] location = new float[2];
        location[0] = System.Convert.ToSingle(networkManager.location[0].Trim('"'));
        location[1] = System.Convert.ToSingle(networkManager.location[1].Trim('"'));
        NetworkPlayers[0].Ship.GetComponent<Rigidbody2D>().transform.position = (new Vector3(location[0], location[1]));
        Debug.Log("x: " + networkManager.location[0] + " y: " + networkManager.location[1]);
	}

    public void AddNetworkPlayer(int id) {
        NetworkPlayers[id] = new NetworkPlayer(id);
    }

    private void SendState() {
        //Debug.Log("character location: " + localPlayer.Ship.transform.position);
        networkManager.sendLocationData("0", localPlayer.Ship.transform.position.x, localPlayer.Ship.transform.position.y);
    }

    private void UpdateFromNetwork (){
    }

    void StartGame() {        
        //this.localPlayer.SpawnShip(ship);
    }
}
