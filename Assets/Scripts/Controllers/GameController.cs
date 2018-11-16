using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject smallasteroid;
    public GameObject mediumasteroid;
    public GameObject largeasteroid;

    private Player player;

    public int MinimumAsteroidRemaining = 10;
    private int MaxAsteroidsSpawnable;
    private int AsteroidsRemaining;
    private int AsteroidSize;
    private int LargeAsteroidCounter;
    private int MediumAsteroidCounter;
    private int CurrentStage = 1 ;
    

	// Use this for initialization
	void Start () {
        GameObject PlayerObject =
            GameObject.FindWithTag("Player");

        player =
            PlayerObject.GetComponent<Player>();

        BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void BeginGame(){

        SpawnAsteroids();
    }

    void SpawnAsteroids(){

        DestroyExistingAsteroids();

        MaxAsteroidsSpawnable = 20;
        AsteroidsRemaining = MaxAsteroidsSpawnable;

        for (int i = 0; i < MaxAsteroidsSpawnable; i++)
        {
            //SERVER: This entire section has to be integrated with the server. The server needs to send a random number
            //between 0 and 2 to select asteroid size, as well as random numbers for the vector and vector rotation to each
            //client, for each asteroid.

            AsteroidSize = Random.Range(0, 2);
            if (AsteroidSize == 0)
            {
                Instantiate(smallasteroid,
                        new Vector3(Random.Range(-14.0f, 14.0f),
                            Random.Range(-5.0f, 5.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 1)
            {
                MediumAsteroidCounter++;
                Instantiate(mediumasteroid,
                        new Vector3(Random.Range(-14.0f, 14.0f),
                            Random.Range(-5.0f, 5.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 0)
            {
                LargeAsteroidCounter++;
                Instantiate(largeasteroid,
                        new Vector3(Random.Range(-14.0f, 14.0f),
                            Random.Range(-5.0f, 5.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
        }

    }

    public void DestroyShip(GameObject DestroyedShip)
    {
        //Things to implement: Respawn at start position, Decrement Lives, invulnerabilty time
        player.Respawn(DestroyedShip);
    }

    public void DestroyAsteroid(GameObject DestroyedAsteroid)
    {
        
        if(DestroyedAsteroid.tag.Equals("SmallAsteroid"))
        {
            Destroy(DestroyedAsteroid);
            AsteroidsRemaining--;
        }

        if (DestroyedAsteroid.tag.Equals("MediumAsteroid"))
        {
            
           //SERVER: Must be updated with asteroid current position and send an offset of that vector to all clients
           //to instantiate the asteroid split vectors
           Instantiate(smallasteroid,
              new Vector3(DestroyedAsteroid.transform.position.x -.5f,
                  DestroyedAsteroid.transform.position.y -.5f, 0),
                  Quaternion.Euler(0, 0, 90));

            Instantiate(smallasteroid,
              new Vector3(DestroyedAsteroid.transform.position.x + .5f,
                  DestroyedAsteroid.transform.position.y + .0f, 0),
                  Quaternion.Euler(0, 0, 0));
              

            Destroy(DestroyedAsteroid);
            AsteroidsRemaining+=1;
            MediumAsteroidCounter--;
        }

        if (DestroyedAsteroid.tag.Equals("LargeAsteroid"))
        {

            //SERVER: Must be updated with asteroid current position and send an offset of that vector to all clients
            //to instantiate the asteroid split vectors
            Instantiate(smallasteroid,
               new Vector3(DestroyedAsteroid.transform.position.x - .5f,
                   DestroyedAsteroid.transform.position.y - .5f, 0),
                   Quaternion.Euler(0, 0, 90));

            Instantiate(smallasteroid,
              new Vector3(DestroyedAsteroid.transform.position.x + .5f,
                  DestroyedAsteroid.transform.position.y + .0f, 0),
                  Quaternion.Euler(0, 0, 0));

            Instantiate(smallasteroid,
               new Vector3(DestroyedAsteroid.transform.position.x + .5f,
                   DestroyedAsteroid.transform.position.y - .5f, 0),
                   Quaternion.Euler(0, 0, 270));

            Instantiate(smallasteroid,
              new Vector3(DestroyedAsteroid.transform.position.x - .5f,
                  DestroyedAsteroid.transform.position.y + .0f, 0),
                  Quaternion.Euler(0, 0, 180));


            Destroy(DestroyedAsteroid);
            AsteroidsRemaining += 3;
            LargeAsteroidCounter--;
        }

        if(AsteroidsRemaining <= MinimumAsteroidRemaining && 
            ((MediumAsteroidCounter*2)+AsteroidsRemaining) <= MinimumAsteroidRemaining &&
            ((LargeAsteroidCounter*4)+AsteroidsRemaining) <= MinimumAsteroidRemaining)
        {
            //SERVER: Inform server condition are met to spawn a new wave
            CurrentStage++;
            SpawnAsteroids();
        }
    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids =
            GameObject.FindGameObjectsWithTag("LargeAsteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 =
            GameObject.FindGameObjectsWithTag("MediumAsteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids3 =
            GameObject.FindGameObjectsWithTag("LargeAsteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }


}
