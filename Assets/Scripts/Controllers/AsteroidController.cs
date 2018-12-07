using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : ObjectController {

    private GameController gameController;
 
  

    void Awake()
    {



    }
    // Use this for initialization
    void Start()
    {

        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();


        /*
        SpriteRenderer spriteRenderer;
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        spriteRenderer.sprite = Resources.Load<Sprite>("asteroid");
        spriteRenderer.material = Resources.Load("Sprites/Materials/AsteroidDesign1", typeof(Material)) as Material;

        CircleCollider2D hitBox;
        hitBox = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        hitBox.radius = (float)2.4;

        /*
        Rigidbody2D body;
        body = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        body.mass = 1;
        body.bodyType = RigidbodyType2D.Dynamic;
        body.simulated = true;
        body.angularDrag = (float)1.0;
        body.sleepMode = RigidbodySleepMode2D.StartAwake;
        body.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        body.gravityScale = (float)0.0;*/


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
            //gameController.DestroyShip(collision.gameObject);
        }


    }
}
