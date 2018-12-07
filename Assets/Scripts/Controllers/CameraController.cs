using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    private Vector3 offset;

    private GameObject gameController;

	// Use this for initialization
	void Start () {

        gameController = GameObject.FindWithTag("GameController");

	}
	
	// Update is called once per frame
	void LateUpdate () {
       // player = gameController.GetComponent<LocalGameManager>().playerShip;

        // offset = transform.position - player.transform.position;

        //  transform.position = player.transform.position + offset;
	}
}
