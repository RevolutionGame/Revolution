using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : Player
{
    public override void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        ship.SetControllerToFreeRoam();
        //this.Ship.controller = new FreeRoamController();        
    }
}
