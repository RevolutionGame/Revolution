
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Ship Ship;
    private int PlayerID;
    protected int id;
    private readonly int radius = 6;
    private Vector3 SpawnPosition;
    private Vector3 SpawnRotation;
    private Vector3[,] Positions = new Vector3[8, 2];
    private GameController gameController;

    void Start () {

        //SERVER: Set player ID 0 to 7 to choose start position
        PlayerID = 4;

       FindSpawnPosition();

       Ship = Instantiate(Ship, SpawnPosition, Quaternion.identity);
       Ship.transform.Rotate(SpawnRotation);

       // Trying out transform RotateAround
       // ship = Instantiate(ship, new Vector3 (radius, 0, 0), Quaternion.identity);
       // ship.transform.RotateAround(Vector3.zero, Vector3.back, -45);
    }

    public void Respawn(GameObject RespawnedShip)
    {
        //Need to update server that ship was moved
        RespawnedShip.transform.position = SpawnPosition;
        RespawnedShip.transform.rotation = Quaternion.identity;
        RespawnedShip.transform.Rotate(SpawnRotation);
    
       // Trying out transform RotateAround
       // RespawnedShip.transform.position = new Vector3(radius, 0, 0);
       // RespawnedShip.transform.rotation = Quaternion.identity;
       // RespawnedShip.transform.RotateAround(Vector3.zero, Vector3.back, -45);

    }

    public void FindSpawnPosition()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "FreeRoamScene")
        {
            //Fill in spawn position array and assign spawn position based off of PlayerID;
            //Temporary code:
            SpawnPosition = new Vector3(0, 0, 0);
            SpawnRotation = new Vector3(0, 0, 0);
        }
        else if (sceneName == "RevolutionScene")
        {
            //Assign Spawn position and Spawn rotation based off of Player ID
            Positions[0, 0] = new Vector3((radius * Mathf.Cos(0)), (radius * Mathf.Sin(0)), 0);
            Positions[0, 1] = new Vector3(0, 0, 90);

            Positions[1, 0] = new Vector3((radius*Mathf.Cos(45 * Mathf.Deg2Rad)), (radius*Mathf.Sin(45 * Mathf.Deg2Rad)), 0);
            Positions[1, 1] = new Vector3(0, 0, 135);

            Positions[2, 0] = new Vector3((radius * Mathf.Cos(90 * Mathf.Deg2Rad)), (radius * Mathf.Sin(90 *Mathf.Deg2Rad)), 0);
            Positions[2, 1] = new Vector3(0, 0, 180);

            Positions[3, 0] = new Vector3((radius * Mathf.Cos(135 * Mathf.Deg2Rad)), (radius * Mathf.Sin(135 * Mathf.Deg2Rad)), 0);
            Positions[3, 1] = new Vector3(0, 0, 225);

            Positions[4, 0] = new Vector3((radius * Mathf.Cos(180 * Mathf.Deg2Rad)), (radius * Mathf.Sin(180 * Mathf.Deg2Rad)), 0);
            Positions[4, 1] = new Vector3(0, 0, 270);

            Positions[5, 0] = new Vector3((radius * Mathf.Cos(225*Mathf.Deg2Rad)), (radius * Mathf.Sin(225*Mathf.Deg2Rad)), 0);
            Positions[5, 1] = new Vector3(0, 0, 315);

            Positions[6, 0] = new Vector3((radius * Mathf.Cos(270*Mathf.Deg2Rad)), (radius * Mathf.Sin(270*Mathf.Deg2Rad)), 0);
            Positions[6, 1] = new Vector3(0, 0, 0);

            Positions[7, 0] = new Vector3((radius * Mathf.Cos(315*Mathf.Deg2Rad)), (radius * Mathf.Sin(315*Mathf.Deg2Rad)), 0);
            Positions[7, 1] = new Vector3(0, 0, 45);

            SpawnPosition = Positions[PlayerID,0];
            SpawnRotation = Positions[PlayerID, 1];

        }
    }

    public int Id
    {
        get { return id; }

    }

    public virtual void SpawnShip(Ship ship)
    {

    }
}
