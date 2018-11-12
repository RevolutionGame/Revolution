using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player 
{

    //   public Ship ship;
    //   void Start () {
    //       ship = Instantiate(ship, new Vector3(), Quaternion.identity);
    //}

    private Ship ship;
    protected int id;

    public int Id
    {
        get
        {
            return id;
        }
    }

    public Ship Ship
    {
        get{ return ship; }
        set { ship = value; }
    }

    public abstract void SpawnShip(Ship ship);
}
