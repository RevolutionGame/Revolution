using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

    public Dictionary<string, NetworkPlayer> networkPlayers = new Dictionary<string, NetworkPlayer>();
    LocalPlayer localPlayer;
    private JSONObject worldJSON = new JSONObject();

    public JSONObject WorldJSON
    {
        get{ return worldJSON; }
        set{ worldJSON = value; }
    }

    public World() {

    }

    public World(JSONObject json) {

    }

    public void UpdateFromJSON(JSONObject json) {
        try
        {
            json.GetField("ships").list.ForEach(ProcessShipJSON);
        } catch(System.NullReferenceException e) {

        }
    }

    private void ProcessShipJSON(JSONObject ship) {
        networkPlayers[ship.GetField("userId").str]
            .MoveTo(ship.GetField("locationX").n,
                    ship.GetField("locationY").n,
                    ship.GetField("angleInDegrees").n);
    }
}
