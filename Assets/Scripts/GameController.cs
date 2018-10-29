using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteroid;

    private int MaxAsteroidsSpawnable;

	// Use this for initialization
	void Start () {
        BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void BeginGame(){

        SpawnAsteroids();
    }

    void SpawnAsteroids(){
        MaxAsteroidsSpawnable = 100;
        for (int i = 0; i < MaxAsteroidsSpawnable; i++)
        {
            Instantiate(asteroid,
                    new Vector3(Random.Range(-9.0f, 9.0f),
                        Random.Range(-6.0f, 6.0f), 0),
                    Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }

    }


}
