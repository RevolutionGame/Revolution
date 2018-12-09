using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ship Class controlls the actual Ship objects in game. They may be attached to
/// either a Player object or a NetworkPlayer object. Ship is responsible for
/// creating projectiles/bullets and moving itself across the game world
/// </summary>
public partial class Ship : MonoBehaviour {

    public MonoBehaviour controller;
    public GameObject[] Bullets;
    GameObject Bullet;

    public int BulletId { get; set; } = 0;

    public float interval = 1.0f;

    //Use this for initialization
    private void Awake()
    {

        //-----------------------------------------------------------------------
        //***Creates a "Bullet Array" and fills it with all available Bullet Prefabs
        //***The DEFAULT bullet object is index 0 and uses the BaseBulletController 
        //      Class. All subsequent bullet objects need a new prefab and possibly 
        //      a new class derived from BaseBulletController.
        //-----------------------------------------------------------------------
        Bullets = new GameObject[10];
        Bullets = Resources.LoadAll<GameObject>("Prefabs/Bullets/");

    }

    void Start ()
    {
        //gameObject.AddComponent<RevolutionController>();

        //Grabs Shot interval from the selected bullet prefab
        SetInterval();

        /*TODO The method InvokeRepeating() needs to be placed into a timed function that waits for
         the gamescene to load and a short "Start up" period befor the game 
         kicks off.  */
        //Auto fires the selected Bullet afetr a 0.5 second delay
        InvokeRepeating("Fire", 0.5f, interval);


    }

    void Update()
    {
        //for quick testing purposes only
        if(Input.GetKeyDown("space"))
        {
            Fire();
        }
    }

    void SetInterval()
    {
        interval = Bullets[BulletId].GetComponent<BaseBulletController>().ShotInterval;
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

        Destroy(gameObject.GetComponent<FreeRoamController>());
        controller = gameObject.AddComponent<RevolutionController>();
        //transform.Rotate(new Vector3(0, 0, -180));
    }

    public void Fire()
    {

        Debug.Log("Fire");
        Bullet = Instantiate(Bullets[BulletId], this.transform.position, transform.rotation );
        
        //TODO Setting Parent of bullet to ship causes matrix effect on bullets
        //Bullet.transform.SetParent(this.transform);
    }

   

}
