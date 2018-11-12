using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Player {

    public NetworkPlayer(int id) {
        this.id = id;
    }

    public override void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        ship.controller = new NullController();
    }
}
