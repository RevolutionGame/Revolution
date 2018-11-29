using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer
{

    public Ship Ship;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Cell { get; set; }
    public string Email { get; set; }


    public void SpawnShip(Ship ship)
    {
        this.Ship = ship;
        this.Ship.UseRevolutionController();
        //this.Ship.controller = new FreeRoamController(this.Ship.GetComponent<Rigidbody2D>());
    }
}
