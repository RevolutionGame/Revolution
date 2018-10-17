using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Ship ship;
    void Start () {
        ship = Instantiate(ship, new Vector3(), Quaternion.identity);
	}
}
