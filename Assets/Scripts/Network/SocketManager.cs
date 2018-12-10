using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Google.Protobuf;
using System;

public struct PlayerData
{
    public uint id;
    public string name;
    public float x;
    public float y;
    public float r;
    public List<ActionType> actions;

    public PlayerData(uint id, string name)
    {
        this.id = id;
        this.name = name;
        x = 0f;
        y = 0f;
        r = 0f;
        actions = new List<ActionType>();
    }
}

public class SocketManager
{

    //const string URL = "ws://morning-reaches-89885.herokuapp.com/lobby";
    const string URL = "ws://localhost:8080/lobby";
    WebSocket socket;
    public Action onGameStart;
    public bool isReady = false;
    public uint localId;

    public PlayerData[] players = new PlayerData[10];
    public PlayerData[] Players
    {
        get { return players; }
    }

    public SocketManager()
    {
        socket = new WebSocket(URL);
    }

    public void Connect(Action onSuccess)
    {
        socket.EmitOnPing = true;
        socket.OnError += (sender, e) =>
        {
            Debug.Log(e.Exception.ToString());
        };
        socket.OnMessage += (sender, e) =>
        {
            if (e.IsBinary)
            {
                Packet packet = Packet.Parser.ParseFrom(e.RawData);
                ParseMessage(packet);
            }
        };
        socket.OnOpen += (sender, e) =>
        {
            Packet packet = new Packet();
            packet.BodyType = BodyType.RequestSlot;
            Send(packet);

            onSuccess();
        };

        socket.Connect();
    }

    void ParseMessage(Packet packet)
    {
        switch (packet.BodyType)
        {
            case BodyType.LobbyInfo:
                Debug.Log("SOCKETMANAGER: Lobby Info");
                OnLobbyInfo(packet);
                break;
            case BodyType.PlayerJoin:
                Debug.Log("SOCKETMANAGER: Player Join");
                OnPlayerJoin(packet);
                break;
            case BodyType.ReadyUp:
                Debug.Log("Lobby is full");
                isReady = true;
                //OnReadyUp();
                break;
            case BodyType.GameStart:
                Debug.Log("Starting Game");
                onGameStart();
                break;
            case BodyType.PlayerLocation:
                Debug.Log("Player Location");
                UpdateLocation(packet.PlayerLocation.Id, packet.PlayerLocation);
                break;
            case BodyType.PlayerAction:
                OnAction(packet.PlayerAction);
                break;
        }
    }

    private PlayerData PlayerFromPacket(PlayerInfo playerInfo)
    {
        return new PlayerData(playerInfo.Id, playerInfo.Name);
    }

    private void OnLobbyInfo(Packet packet)
    {
        localId = packet.LobbyInfo.Id;
        foreach (PlayerInfo playerInfo in packet.LobbyInfo.Players)
        {
            if (localId != playerInfo.Id)
            {
                players[playerInfo.Id] = new PlayerData(playerInfo.Id, playerInfo.Name);
            }
        }
    }

    private void OnPlayerJoin(Packet packet)
    {
        players[packet.PlayerInfo.Id] = new PlayerData(packet.PlayerInfo.Id, packet.PlayerInfo.Name);
    }

    public void OnReadyUp()
    {
        Packet packet = new Packet();
        packet.BodyType = BodyType.PlayerReady;
        Send(packet);
    }

    public void Send(Packet packet)
    {
        this.socket.Send(packet.ToByteArray());
    }

    public void OnAction(PlayerAction playerAction)
    {
        switch(playerAction.ActionType)
        {
            case ActionType.DespawnShip:
                players[playerAction.PlayerTarget].actions.Add(ActionType.DespawnShip);
                break;
            case ActionType.FireGun:
                break;
            case ActionType.HitAsteroid:
                break;
            case ActionType.HitPlayer:
                break;
            case ActionType.SpawnShip:
                break;
        }
    }

    private void UpdateLocation(uint id, PlayerLocation location)
    {
        players[id].x = location.X;
        players[id].y = location.Y;
        players[id].r = location.R;
    }
}
