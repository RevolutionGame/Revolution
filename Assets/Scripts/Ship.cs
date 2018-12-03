using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Ship : MonoBehaviour {

    public MonoBehaviour controller;

    GameObject Bullet;
 
	//Use this for initialization
    void Start ()
    {
        Bullet = Resources.Load<GameObject>("Prefabs/Bullet");

        InvokeRepeating("Fire", 0.5f, 0.25f);

    }

    void Update()
    {

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

    public void Fire()
    {
        //Instantiate(Bullet, new Vector3( Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        Instantiate(Bullet, transform );
        //timeAtLastShot = Time.time;

    }

}
