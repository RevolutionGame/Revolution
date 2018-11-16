using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Ship ship;
    private Vector3 StartPosition;
    private GameController gameController;

    void Start () {

        //SERVER: Ask server for start/respawn position. If we decide to define these positions beforehand, server can
        //just assign a number 0 to 9, and player can get its position from the predefined array/list of start positions
        StartPosition = new Vector3(0, 0, 0);

        ship = Instantiate(ship, StartPosition, Quaternion.identity);
	}

    public void Respawn(GameObject RespawnedShip)
    {
        //Need to update server that ship was moved
        RespawnedShip.transform.position = StartPosition;
        
    }
}
