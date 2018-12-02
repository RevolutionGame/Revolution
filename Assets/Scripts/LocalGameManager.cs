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
        networkManager.socketManager.onGameStart = OnGameStart;
        networkManager.socketManager.onGameEnd = OnGameEnd;
        networkManager.socketManager.onPlayerJoin = OnPlayerJoin;
        networkManager.socketManager.onPlayerDisconnect = OnPlayerDisconnect;
        networkManager.socketManager.onPlayerLocation = OnPlayerLocation;
        networkManager.socketManager.onWorldInfo = OnWorldInfo;
        networkManager.socketManager.onLobbyInfo = OnLobbyInfo;        
        networkManager.socketManager.ConnectToSocket();        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateWorld();
	}

    public void AddNetworkPlayer(int id) {        
    }

    private void SendState() {
    }

    private void UpdateFromNetwork (){
    }

    void StartGame() {
        //this.localPlayer.SpawnShip(ship);
        Debug.Log("Game Start");
    }

    void EndGame()
    {
        Debug.Log("Game Over");
    }

    void OnGameStart() 
    {
        networkManager.socketManager.onGameStart = StartGame;
    }

    void OnGameEnd() 
    {
        EndGame();
    }

    void OnPlayerJoin(int id, string playerName)
    {
        Debug.Log($"Player Connected: {playerName} has connected with ID of {id}");
    }

    void OnPlayerDisconnect(int id)
    {
        Debug.Log($"Player Disconnected: ID {id} has discconected");
    }

    void OnLobbyInfo(int id, PlayerInfo[] players)
    {
        Debug.Log($"LobbyInfo: Your ID is :{id} and there are {players.Length} in the lobby already");
        localPlayer.Id = id;

    }

    void OnPlayerLocation(int id, float x, float y, float r)
    {
        Debug.Log($"PlayerLocation: Player{id}'s location is x: {x} y: {y} r: {r}");
    }

    void OnWorldInfo(ObjectLocation[] aseroids)
    {

    }

    void UpdateWorld()
    {
        foreach(string playerName in networkManager.socketManager.world.playerInfos)
        {
            if(playerName != null)
            {
                //Debug.Log($"{playerName}");
            }
        }
    }
}
