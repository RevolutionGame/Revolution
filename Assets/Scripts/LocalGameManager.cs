using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour {

    private LocalPlayer localPlayer;
    public Ship ship;
    public NetworkManager networkManager;
    private int localID;
    private World world = new World();      

    // Use this for initialization
    void Start () {
        localPlayer = new LocalPlayer();
        localPlayer.SpawnShip(Instantiate(ship,  new Vector3(0, 3), Quaternion.identity));
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //SendState();
        //world.UpdateFromJSON(world.WorldJSON);
	}

    /*
    private void SendState() {
        JSONObject json = new JSONObject();
        JSONObject location = new JSONObject();
        location.AddField("locationX", localPlayer.ship.transform.position.x);
        location.AddField("locationY", localPlayer.ship.transform.position.y);
        location.AddField("rotationInDegrees", localPlayer.ship.transform.rotation.eulerAngles.z);
        json.AddField("roomId", "room1");
        json.AddField("location", location);
        networkManager.SendLocationData(json);
    }
    */

    private void UpdateFromNetwork (){
    }

    void StartGame() {
        
    }

    private void SpawnNetworkPlayerShips() {
        foreach (NetworkPlayer networkPlayer in world.networkPlayers.Values) {
            networkPlayer.SpawnShip(ship);
        }
    }

}
