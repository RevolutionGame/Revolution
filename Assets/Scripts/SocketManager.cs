using WebSocketSharp;
using UnityEngine;
using System;
using System.Collections.Generic;
using Google.Protobuf;

public class SocketManager {

    WebSocket socket;
    public Action<int, float, float, float> onPlayerLocation;
    public Action<int, string> onPlayerJoin;
    public Action<int, PlayerInfo[]> onLobbyInfo;
    public Action<int> onPlayerDisconnect;
    public Action onGameStart;
    public Action onGameEnd;
    public Action<ObjectLocation[]> onWorldInfo;
    private World world = new World();

    public SocketManager(string url) 
    {        
        socket = new WebSocket(url);
        socket.EmitOnPing = true;
        socket.OnMessage += (sender, e) =>
        {
            if(e.IsBinary)
            {
                var packet = Packet.Parser.ParseFrom(e.RawData);
                ParseMessage(packet);
            }
            else if(e.IsPing) 
            {
                Debug.Log("Ping recived from server");
            }
        };
        socket.OnOpen += (sender, e) =>
        {
            Debug.Log("Connection Open");
            Packet packet = new Packet();
            PlayerInfo playerInfo = new PlayerInfo();
            playerInfo.Name = "Cody";
            packet.BodyType = BodyType.RequestSlot;
            packet.PlayerInfo = playerInfo;
            SendToServer(packet);
        };
    }

    public void ConnectToSocket()
    {
        socket.Connect();
    }

    private void DisconnectFromSocket() 
    {
        socket.Close();
    }

    public void ParseMessage(Packet packet)
    {
        switch (packet.BodyType)
        {
            case BodyType.LobbyInfo:
                Debug.Log("Lobby Info");
                //Put players into a list then into an array
                var playersPacket = packet.LobbyInfo.Players;
                var players = new List<PlayerInfo>();
                foreach(PlayerInfo player in playersPacket) {
                    players.Add(player);
                }                
                onLobbyInfo((int)packet.LobbyInfo.PlayerId, players.ToArray());
                break;
            case BodyType.PlayerJoin:
                onPlayerJoin((int)packet.PlayerInfo.Id, packet.PlayerInfo.Name);
                break;
            case BodyType.PlayerLocation:
                Debug.Log("Player Location");
                onPlayerLocation((int)packet.PlayerLocation.PlayerId,
                                 packet.PlayerLocation.X,
                                 packet.PlayerLocation.Y,
                                 packet.PlayerLocation.R);
                break;
            case BodyType.PlayerDisconnect:
                Debug.Log("Player Disconnect");
                onPlayerDisconnect((int)packet.PlayerInfo.Id);
                break;
            case BodyType.GameEnd:
                Debug.Log("Game End");
                onGameEnd();
                break;
            case BodyType.WorldInfo:
                Debug.Log("World Info");

                break;
            case BodyType.GameStart:
                Debug.Log("Game Start");
                onGameStart();
                break;
        }
    }

    public void SendToServer(Packet packet)
    {
        socket.Send(packet.ToByteArray());
    }
}
