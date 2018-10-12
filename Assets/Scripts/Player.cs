using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string userName;
    public Controller controller;
	void Start () {
        controller = new FreeRoamController();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            controller.Forward(GetComponent<Rigidbody2D>());
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Left(GetComponent<Rigidbody2D>());
        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Right(GetComponent<Rigidbody2D>());
        }
    }
}
