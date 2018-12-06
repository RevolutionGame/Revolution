using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : Player
{

    public string Email;
    public string Name;

    public override void SpawnShip(Ship ship)
    {
        //this.Ship = ship;
        //this.Ship.UseRevolutionController();
        //this.Ship.controller = new FreeRoamController(this.Ship.GetComponent<Rigidbody2D>());
    }
}
