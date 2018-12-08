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
    public NetworkManager networkManager;
    private int localID;
    private World world = new World();      

    private void Awake()
    {


        //Check if Network Manager Already Exist
        if (NetworkManager.NetworkInstance == null)
        {
            //Create an instance of Network Manager if none exist
            Instantiate(networkManager);

        }

        NetworkManager.NetworkInstance.socketManager.onGameStart = EnableMovement;

    }

    // Use this for initialization
    void Start() {

        //NetworkManager.Instance.socketManager.OnReadyUp();

      GameObject smallAsteroid = Resources.Load<GameObject>("Prefabs/SmallAsteroid");

      GameObject playerShip = Resources.Load<GameObject>("Prefabs/Player");
      
      Instantiate(playerShip);


                localPlayer = playerShip.GetComponent<Player>();

                localPlayer.Id = NetworkManager.NetworkInstance.socketManager.localId;
        
        //Instantiate(playerShip, new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        NetworkManager.NetworkInstance.socketManager.OnReadyUp();
        PopulateNetworkPlayers();

        //localPlayer.SpawnShip(ship);
        //localPlayer.Id = NetworkManager.NetworkInstance.socketManager.localId;

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
                //Player newNetworkPlayer = Instantiate(playerPrefab);
                //players[playerData.id] = newNetworkPlayer;
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

    private void SpawnNetworkPlayerShips() {
        foreach (NetworkPlayer networkPlayer in world.networkPlayers.Values) {
            //networkPlayer.SpawnShip(ship);
        }
    }


}
