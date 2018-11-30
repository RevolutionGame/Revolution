using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Player {



    public NetworkPlayer(int id, string name) {
        this.id = id;
        this.name = name;
    }

    public void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        //ship.controller = new NullController();
    }
}
