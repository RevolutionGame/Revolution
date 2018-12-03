using UnityEngine;

public struct Coords 
{
    float x;
    float y;
    float r;

    public Coords(PlayerLocation playerLocation)
    {
        x = playerLocation.X;
        y = playerLocation.Y;
        r = playerLocation.R;
    }
}

public class World
{
    public Coords[] playerLocations;
    public string[] playerInfos;

    public World()
    {
        this.playerInfos = new string[2];
        this.playerLocations = new Coords[2];
    }

    public void UpdatePlayersInfos(PlayerInfo[] playerInfos)
    {
        foreach(PlayerInfo player in playerInfos)
        {
            this.playerInfos[player.Id] = player.Name;
            Debug.Log($"WORLD: {player.Name} already in Lobby");
        }
    }

    public void UpdatePlayerLocations(PlayerLocation[] playerLocations)
    {
        foreach(PlayerLocation location in playerLocations)
        {
            this.playerLocations[location.PlayerId] = new Coords(location);
        }
    }

    public void AddPlayerInfo(PlayerInfo playerInfo)
    {
        this.playerInfos[playerInfo.Id] = playerInfo.Name;
        Debug.Log($"WORLD: Added {playerInfo.Name}");
    }

    public void SetPlayerLocation(PlayerLocation location)
    {
        this.playerLocations[location.PlayerId] = new Coords(location);
    }

    public bool IsFull()
    {        
        foreach(string player in playerInfos)
        {
            if(player == null)
            {
                return false;
            }
        }
        return true;
    }
}