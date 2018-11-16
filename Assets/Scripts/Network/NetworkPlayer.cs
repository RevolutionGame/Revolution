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
        //ship.controller = new NullController();
    }

    public void MoveTo(float x, float y, float theta) {
        Ship.transform.Translate(new Vector2(x, y));
        Ship.transform.Rotate(new Vector3(0, 0, theta));
    }
}
