using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Player {
    int id;



    public NetworkPlayer(int id) {
        this.id = id;
    }

    
    public override void SpawnShip(Ship ship)
    {
        this.ship = ship;
        //this.ship.UseRevolutionController();
    }

    public void MoveTo(float x, float y, float theta) {
      this.ship.transform.Translate(new Vector2(x, y));
      this.ship.transform.Rotate(new Vector3(0, 0, theta));
    }


}
