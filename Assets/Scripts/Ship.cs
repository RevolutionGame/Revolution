using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public MonoBehaviour controller;
 
	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
    void FixedUpdate () {
        Debug.Log("Position: " + transform.position.ToString());
    }

    public void UseFreeRoamController() {
        Destroy(gameObject.GetComponent<RevolutionController>());
        controller = gameObject.AddComponent<FreeRoamController>();
    }

    public void UseRevolutionController() {
        gameObject.GetComponent<FreeRoamController>();
        controller = gameObject.AddComponent<RevolutionController>();
        transform.Rotate(new Vector3(0, 0, -180));
    }
}
