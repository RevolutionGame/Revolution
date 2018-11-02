using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Controller controller;

	// Use this for initialization
	void Start () {
        //this.controller = new FreeRoamController(GetComponent<Rigidbody2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {            
            this.controller.Forward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.controller.Left();            
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.controller.Right();
        }
        //Debug.Log("Position: " + transform.position.ToString());
    }
}
