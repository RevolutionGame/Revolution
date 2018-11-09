using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    Controller shipcontroller;
    public GameObject bullet;

    private GameController gameController;

	// Use this for initialization
	void Start () {
        shipcontroller = new FreeRoamController(GetComponent<Rigidbody2D>());

        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {            
            shipcontroller.Forward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            shipcontroller.Left();            
        }
        if (Input.GetKey(KeyCode.D))
        {
            shipcontroller.Right();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
        Debug.Log("Position: " + transform.position.ToString());
    }

    void ShootBullet()
    {

        //Create offset from ships current position and rotation.

        Vector3 offset = transform.rotation * new Vector3(0, 1.0f, 0);

        //SERVER: Update server that a bullet was spawned. Update before creating offset, and let server
        //position+offset for synchronization?
        Instantiate(bullet, transform.position + offset, transform.rotation);

    }
}
