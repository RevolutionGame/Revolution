using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Controller controller;

	// Use this for initialization
	void Start () {
        controller = new RevolutionController(GetComponent<Rigidbody2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {            
            controller.Forward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Left();            
        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Right();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Fire();
        }
        Debug.Log("Position: " + transform.position.ToString());
    }
}
