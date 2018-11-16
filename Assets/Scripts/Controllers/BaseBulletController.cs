using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletController : MonoBehaviour
{
    public float BulletSpeed = 400f;
    public float lifetime = 2.0f;
    private GameController gameController;
    // Use this for initialization
    void Start()
    {

        // Set the bullet to destroy itself after 1 seconds
        Destroy(gameObject, lifetime);

        // Push the bullet in the direction it is facing
        GetComponent<Rigidbody2D>()
              .AddForce(transform.up * BulletSpeed);

        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When health interface is added, determine the amount of health to decrement here
        if(collision.gameObject.tag.Equals("BaseBullet")) //Check for upgrades as well when upgrades are implemented
        {
            //When healthbar is implemented we want to decrement the bullet health, and destroy bullet upon health reach 0.
            //That way bullets can be used to defend against each other, and upgraded bullets will have the advantage
            //For now, all BaseBullets destroy each other on impact

        }

        if(collision.gameObject.tag.Equals("Ship"))
        {
            //Decrement health of ship based on bulletupgrade, when ships health reaches 0 destroy ship
            gameController.DestroyShip(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("SmallAsteroid") || collision.gameObject.tag.Equals("MediumAsteroid") ||
            collision.gameObject.tag.Equals("LargeAsteroid"))
        {
            //Decrement health of asteroid based on bulletupgrade, when asteroid health reaches 0 split/destroy asteroid
            gameController.DestroyAsteroid(collision.gameObject);
        }

        //if bullethealth equals 0
        Destroy(gameObject);
    }

}
