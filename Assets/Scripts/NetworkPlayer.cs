using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Player {



    public NetworkPlayer(int id) {
        this.id = id;
    }

    public void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        Ship.shipcontroller = new NullController();
    }
}
