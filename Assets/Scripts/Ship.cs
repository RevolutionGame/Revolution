using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Ship : MonoBehaviour {

    public MonoBehaviour controller;
    public GameObject[] Bullets;
    GameObject Bullet;
 
	//Use this for initialization
    void Start ()
    {
        gameObject.AddComponent<RevolutionController>();

        Bullets = new GameObject[10];

        Bullets[1] = Resources.Load<GameObject>("Prefabs/Bullet");
       
        InvokeRepeating("Fire", 0.5f, 0.2f);

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

    public void UseRevolutionController()
    {

        gameObject.GetComponent<FreeRoamController>();
        controller = gameObject.AddComponent<RevolutionController>();
        //transform.Rotate(new Vector3(0, 0, -180));
    }

    public void Fire()
    {

        Debug.Log("Fire");
        Bullet = Instantiate(Bullets[1], this.transform.position, transform.rotation );
        
        //Setting Parent of bullet to ship causes matrix effect on bullets
        //Bullet.transform.SetParent(this.transform);
    }

   

}
