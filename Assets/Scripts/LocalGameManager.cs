using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour {

    public Player[] players = new Player[9];
    public Player playerPrefab;
    public Player localPlayer;

    public RevolutionController freeRoamController;
    public bool isEnabled = false;

    public Ship ship;
    //public NetworkManager networkManager;
    private int localID;
    private World world = new World();

    public bool Flag = false;

    private void Awake()
    {

        NetworkManager.NetworkInstance.socketManager.onGameStart = EnableMovement;

    }

    // Use this for initialization
    void Start() {

        //-----------------------------------------------------------------------
        //***Load Player Prefab and grab Player Component so we can use it.
        //***Here we are only creating the local player object. Use this method to 
        //   create the remaining network players in lobby.
        //-----------------------------------------------------------------------
        /*TODO Consider placing the following two lines into a method that loops through
         * and creates each players gameobject and then sets the proper values in the 
         * Player/NetworkPlayer classes
         */
        GameObject playerShip = (GameObject)Instantiate(Resources.Load("Prefabs/Player"));
        localPlayer = playerShip.GetComponent<Player>();


        //TODO move to UIManager
        while (!Flag)
        {
            NetworkManager.NetworkInstance.socketManager.Connect(Connected);
        }

        localPlayer.Id = NetworkManager.NetworkInstance.socketManager.localId;
       
        PopulateNetworkPlayers();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnabled)
        {
        }
        if (isEnabled)
        {
            SendLocation();
            UpdatePlayers();
        }
    }

    private void PopulateNetworkPlayers()
    {
        foreach (PlayerData playerData in NetworkManager.NetworkInstance.socketManager.players)
        {
            if (playerData.name != null)
            {
                GameObject playerShip = (GameObject)Instantiate(Resources.Load("Prefabs/Player"));
                Player newNetworkPlayer = playerShip.GetComponent<Player>();
                players[playerData.id] = newNetworkPlayer;
            }
        }

        NetworkManager.NetworkInstance.socketManager.OnReadyUp();
    }

    void EnableMovement()
    {
        isEnabled = true;
    }

    void SendLocation()
    {
        RevProtocol.Packet packet = new RevProtocol.Packet();
        packet.BodyType = RevProtocol.BodyType.PlayerLocation;
        RevProtocol.PlayerLocation location = new RevProtocol.PlayerLocation();
        location.Id = NetworkManager.NetworkInstance.socketManager.localId;
        location.X = localPlayer.shipInstance.transform.position.x;
        location.Y = localPlayer.shipInstance.transform.position.y;
        location.R = localPlayer.shipInstance.transform.rotation.eulerAngles.z;
        packet.Location = location;
        NetworkManager.NetworkInstance.socketManager.Send(packet);

    }

    void UpdatePlayers()
    {
        foreach (PlayerData playerData in NetworkManager.NetworkInstance.socketManager.Players)
        {

            Debug.Log($"PLAYER LOCATION: x: {playerData.x} y: {playerData.y} r: {playerData.r}");
            players[playerData.id].shipInstance.transform.position = new Vector2(playerData.x, playerData.y);
            players[playerData.id].shipInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerData.r));
        }
    }

    private void UpdateFromNetwork (){
    }

    void StartGame() {
        
    }

    /*
    private void SpawnNetworkPlayerShips() {
        foreach (NetworkPlayer networkPlayer in world.networkPlayers.Values) {
            networkPlayer.SpawnShip(ship);
        }
    }
    */
    public void Connected()
    {
        //yield return null;

        Flag = true;
    }

}
