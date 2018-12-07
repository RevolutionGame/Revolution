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

    public PlayerData(uint id, string name)
    {
        this.id = id;
        this.name = name;
        x = 0f;
        y = 0f;
        r = 0f;
    }
}

public class SocketManager
{

    const string URL = "ws://young-lowlands-93365.herokuapp.com/lobby";
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
                RevProtocol.Packet packet = RevProtocol.Packet.Parser.ParseFrom(e.RawData);
                ParseMessage(packet);
            }
        };
        socket.OnOpen += (sender, e) =>
        {
            RevProtocol.Packet packet = new RevProtocol.Packet();
            packet.BodyType = RevProtocol.BodyType.RequestSlot;
            Send(packet);

            onSuccess();
        };

        socket.Connect();
    }

    void ParseMessage(RevProtocol.Packet packet)
    {
        switch (packet.BodyType)
        {
            case RevProtocol.BodyType.LobbyInfo:
                Debug.Log("SOCKETMANAGER: Lobby Info");
                OnLobbyInfo(packet);
                break;
            case RevProtocol.BodyType.PlayerJoin:
                Debug.Log("SOCKETMANAGER: Player Join");
                OnPlayerJoin(packet);
                break;
            case RevProtocol.BodyType.Readyup:
                Debug.Log("Lobby is full");
                isReady = true;
                break;
            case RevProtocol.BodyType.GameStart:
                Debug.Log("Starting Game");
                onGameStart();
                break;
            case RevProtocol.BodyType.PlayerLocation:
                Debug.Log("Player Location");
                UpdateLocation(packet.Location.Id, packet.Location);
                break;
        }
    }

    private PlayerData PlayerFromPacket(RevProtocol.PlayerInfo playerInfo)
    {
        return new PlayerData(playerInfo.Id, playerInfo.Name);
    }

    private void OnLobbyInfo(RevProtocol.Packet packet)
    {
        localId = packet.LobbyInfo.Id;
        foreach (RevProtocol.PlayerInfo playerInfo in packet.LobbyInfo.Players)
        {
            players[playerInfo.Id] = new PlayerData(playerInfo.Id, playerInfo.Name);
        }
    }

    private void OnPlayerJoin(RevProtocol.Packet packet)
    {
        players[packet.PlayerInfo.Id] = new PlayerData(packet.PlayerInfo.Id, packet.PlayerInfo.Name);
    }

    public void OnReadyUp()
    {
        RevProtocol.Packet packet = new RevProtocol.Packet();
        packet.BodyType = RevProtocol.BodyType.PlayerReady;
        Send(packet);
    }

    public void Send(RevProtocol.Packet packet)
    {
        this.socket.Send(packet.ToByteArray());
    }

    private void UpdateLocation(uint id, RevProtocol.PlayerLocation location)
    {
        players[id].x = location.X;
        players[id].y = location.Y;
        players[id].r = location.R;
    }
}
