using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    GameObject smallAsteroid;
    GameObject mediumAsteroid;
    GameObject largeAsteroid;

    public NetworkManager networkManager;

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

        largeAsteroid = Resources.Load<GameObject>("Prefabs/LargeAsteroid");
        mediumAsteroid = Resources.Load<GameObject>("Prefabs/MediumAsteroid");
        smallAsteroid = Resources.Load<GameObject>("Prefabs/SmallAsteroid");

        BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void BeginGame(){
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "FreeRoamScene")
        {
            //SpawnFreeAsteroids();
        }else if (sceneName == "RevolutionScene")
        {
            SpawnRevolutionAsteroids();
        }
   }

    void SpawnRevolutionAsteroids()
    {
        DestroyExistingAsteroids();

        MaxAsteroidsSpawnable = 10;
        AsteroidsRemaining = MaxAsteroidsSpawnable;

        for (int i = 0; i < MaxAsteroidsSpawnable; i++)
        {
            //SERVER: This entire section has to be integrated with the server. The server needs to send a random number
            //between 0 and 2 to select asteroid size, as well as random numbers for the vector and vector rotation to each
            //client, for each asteroid.

            AsteroidSize = Random.Range(0, 2);
            if (AsteroidSize == 0)
            {
                Instantiate(smallAsteroid,
                        new Vector3(Random.Range(-4.0f, 4.0f),
                            Random.Range(-4.0f, 4.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 1)
            {
                MediumAsteroidCounter++;
                Instantiate(mediumAsteroid,
                        new Vector3(Random.Range(-4.0f, 4.0f),
                            Random.Range(-4.0f, 4.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 2)
            {
                LargeAsteroidCounter++;
                Instantiate(largeAsteroid,
                        new Vector3(Random.Range(-4.0f, 4.0f),
                            Random.Range(-4.0f, 4.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
        }
    }

    void SpawnRevolutionAsteroidsWithConnection(int ID, int sectors, float[,] vectors) //[ID, (size, x, y, angle)]
                                                                                       // The angle in vector[ID,3] must be < 360/sectors
    {

        AsteroidSize = (int)vectors[ID, 0];
        
            float radius = Mathf.Sqrt(((Mathf.Pow(vectors[ID,1], 2) + Mathf.Pow(vectors[ID,2], 2))));
            
            for (int i = 0; i < sectors; i++)
            {
                
                float angle = ((i * (360 / sectors)) + vectors[ID, 3]);
                
                if (angle == 360) //Might not need this
                {
                    angle = 0;
                }

                if (AsteroidSize == 0)
                {
                        Instantiate(smallAsteroid,
                                    new Vector3(radius*(Mathf.Cos(angle*Mathf.Deg2Rad)), radius*(Mathf.Sin(angle*Mathf.Deg2Rad)), 0), 
                                    Quaternion.Euler(0, 0, angle));
                }

                if (AsteroidSize == 1)
                {
                        Instantiate(mediumAsteroid,
                                new Vector3(radius * (Mathf.Cos(angle * Mathf.Deg2Rad)), radius * (Mathf.Sin(angle * Mathf.Deg2Rad)), 0),
                                Quaternion.Euler(0, 0, angle));


                }
                if (AsteroidSize == 2)
                {
                    Instantiate(largeAsteroid,
                                new Vector3(radius * (Mathf.Cos(angle * Mathf.Deg2Rad)), radius * (Mathf.Sin(angle * Mathf.Deg2Rad)), 0),
                                Quaternion.Euler(0, 0, angle));


                }
            }

        

    }

    void SpawnRevolutionAsteroidsProd(int sectors, int size) //[ID, (size, x, y, angle)]                                                                                
   {

        AsteroidSize = size;

        //float radius = Mathf.Sqrt(((Mathf.Pow(vectors[ID, 1], 2) + Mathf.Pow(vectors[ID, 2], 2))));

        for (int i = 0; i < sectors; i++)
        {

            float angle = ((i * (360 / sectors)));

            if (angle == 360) //Might not need this
            {
                angle = 0;
            }

            if (AsteroidSize == 0)
            {
                Instantiate(smallAsteroid,
                            new Vector3(0, 0, 0),
                            Quaternion.Euler(0, 0, angle));
            }

            if (AsteroidSize == 1)
            {
                Instantiate(mediumAsteroid,
                        new Vector3(0, 0, 0),
                        Quaternion.Euler(0, 0, angle));


            }
            if (AsteroidSize == 2)
            {
                Instantiate(largeAsteroid,
                            new Vector3(0, 0, 0),
                            Quaternion.Euler(0, 0, angle));

            }
        }



    }

    void SpawnFreeAsteroids(){

        DestroyExistingAsteroids();

        MaxAsteroidsSpawnable = 10;
        AsteroidsRemaining = MaxAsteroidsSpawnable;

        for (int i = 0; i < MaxAsteroidsSpawnable; i++)
        {
            //SERVER: This entire section has to be integrated with the server. The server needs to send a random number
            //between 0 and 2 to select asteroid size, as well as random numbers for the vector and vector rotation to each
            //client, for each asteroid.

            AsteroidSize = Random.Range(0, 2);
            if (AsteroidSize == 0)
            {
                Instantiate(smallAsteroid,
                        new Vector3(Random.Range(-14.0f, 14.0f),
                            Random.Range(-5.0f, 5.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 1)
            {
                MediumAsteroidCounter++;
                Instantiate(mediumAsteroid,
                        new Vector3(Random.Range(-14.0f, 14.0f),
                            Random.Range(-5.0f, 5.0f), 0),
                        Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            }
            if (AsteroidSize == 0)
            {
                LargeAsteroidCounter++;
                Instantiate(largeAsteroid,
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
        Quaternion offset = Quaternion.FromToRotation(Vector3.up, DestroyedAsteroid.transform.rotation.eulerAngles);
        if(DestroyedAsteroid.tag.Equals("SmallAsteroid"))
        {
            Destroy(DestroyedAsteroid);
            //AsteroidsRemaining--;
        }

        if (DestroyedAsteroid.tag.Equals("MediumAsteroid"))
        {
            
           //SERVER: Must be updated with asteroid current position and send an offset of that vector to all clients
           //to instantiate the asteroid split vectors
           Instantiate(smallAsteroid,
              new Vector3(DestroyedAsteroid.transform.position.x,
                  DestroyedAsteroid.transform.position.y, 0),
                  Quaternion.Euler(0, 0, offset.eulerAngles.z - 45));

            Instantiate(smallAsteroid,
              new Vector3(DestroyedAsteroid.transform.position.x,
                  DestroyedAsteroid.transform.position.y, 0),
                  Quaternion.Euler(0, 0, offset.eulerAngles.z + 45));
              

            Destroy(DestroyedAsteroid);
            //AsteroidsRemaining+=1;
            //MediumAsteroidCounter--;
        }

        if (DestroyedAsteroid.tag.Equals("LargeAsteroid"))
        {

            //SERVER: Must be updated with asteroid current position and send an offset of that vector to all clients
            //to instantiate the asteroid split vectors
            Instantiate(smallAsteroid,
               new Vector3(DestroyedAsteroid.transform.position.x,
                   DestroyedAsteroid.transform.position.y, 0),
                   Quaternion.Euler(0, 0, offset.eulerAngles.z - 45));

            Instantiate(smallAsteroid,
              new Vector3(DestroyedAsteroid.transform.position.x,
                  DestroyedAsteroid.transform.position.y, 0),
                  Quaternion.Euler(0, 0, offset.eulerAngles.z - 15));

            Instantiate(smallAsteroid,
               new Vector3(DestroyedAsteroid.transform.position.x,
                   DestroyedAsteroid.transform.position.y, 0),
                   Quaternion.Euler(0, 0, offset.eulerAngles.z + 15);

            Instantiate(smallAsteroid,
              new Vector3(DestroyedAsteroid.transform.position.x,
                  DestroyedAsteroid.transform.position.y, 0),
                  Quaternion.Euler(0, 0, offset.eulerAngles.z + 45));


            Destroy(DestroyedAsteroid);
            //AsteroidsRemaining += 3;
            //LargeAsteroidCounter--;
        }

        //if(AsteroidsRemaining <= MinimumAsteroidRemaining && 
          //  ((MediumAsteroidCounter*2)+AsteroidsRemaining) <= MinimumAsteroidRemaining &&
            //((LargeAsteroidCounter*4)+AsteroidsRemaining) <= MinimumAsteroidRemaining)
        ///{
            //SERVER: Inform server condition are met to spawn a new wave
         //   CurrentStage++;
          //  BeginGame();
        //}
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
