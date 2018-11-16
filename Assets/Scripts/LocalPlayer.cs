using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : Player
{
    public override void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        this.Ship.shipcontroller = new FreeRoamController(this.Ship.GetComponent<Rigidbody2D>());
    }
}
