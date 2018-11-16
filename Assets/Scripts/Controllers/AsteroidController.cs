using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    private GameController gameController;

    // Use this for initialization
    void Start()
    {

        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();

        // Push the asteroid in the direction it is facing
        if (gameObject.tag == "SmallAsteroid")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 150);
            GetComponent<Rigidbody2D>().angularVelocity = 90;
        }
        else if(gameObject.tag == "MediumAsteroid")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            GetComponent<Rigidbody2D>().angularVelocity = 60;
        }
        else if (gameObject.tag == "LargeAsteroid")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
            GetComponent<Rigidbody2D>().angularVelocity = 30;
        }

    }

    //Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Ship"))
        {
            gameController.DestroyShip(collision.gameObject);
        }


    }
}
