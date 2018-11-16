using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class Ship : MonoBehaviour {

    public Controller shipcontroller;
    public GameObject bullet;

    private GameController gameController;



    // Use this for initialization
    void Start () {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
/*
        if (sceneName == "FreeRoamScene")
        {
            shipcontroller = new FreeRoamController(GetComponent<Rigidbody2D>());
        }
        else if (sceneName == "RevolutionScene")
        {
            shipcontroller = new RevolutionController(GetComponent<Rigidbody2D>());
        }
*/
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();
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
