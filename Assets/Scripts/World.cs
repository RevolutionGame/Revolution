using System;
public class World
{
    PlayerLocation[] playerLocations = new PlayerLocation[10];
    PlayerInfo[] playerInfos = new PlayerInfo[10];

    public World(PlayerLocation[] playerLocations, PlayerInfo[] playerInfos)
    {
        this.playerLocations = playerLocations;
        this.playerInfos = playerInfos;
    }


}