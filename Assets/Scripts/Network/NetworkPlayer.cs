using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NetworkPlayer : MonoBehaviour {

    public uint id;
    public GameObject[] ShipPrefabs;
    //public Ship ship;
    public Ship shipInstance;
    public readonly int radius = 12;
    Ship Ship;


    public uint Id
    {
        get { return id; }
        set { id = value; }
    }

    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }


    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        ShipPrefabs = new GameObject[10];
        ShipPrefabs = Resources.LoadAll<GameObject>("Prefabs/ShipPrefabs/");

        Vector3[] spawn = FindSpawnPosition(sceneName);

        //TODO Make Ship Prefab selection dynamic based on users selection or default 
        //-----------------------------------------------------------------------
        //Here The player ship is created using the selected Prefab, at radius 5
        //This still needs to be refined a bit. For now ship selection is preset
        //and the spawn position is still a bit iffy
        //-----------------------------------------------------------------------
        try
        {
            shipInstance = Instantiate(ShipPrefabs[NetworkManager.networkInstance.socketManager], spawn[0], Quaternion.Euler(spawn[1].x, spawn[1].y, spawn[1].z)).GetComponent<Ship>();
            if (sceneName == "FreeRoamScene")
            {
                //Adds the boundary crossing logic to ships on free roam. The values for the boundaries have to be calculated via radius
                //shipInstance.gameObject.AddComponent<EuclideanTorus>();
            }
        }
        catch (ArgumentNullException)
        {
            Debug.Log("spawn vector is null");
            shipInstance = Instantiate(ShipPrefabs[0], new Vector3(0, -12, 0), transform.rotation).GetComponent<Ship>();
            if (sceneName == "FreeRoamScene")
            {
                //Adds the boundary crossing logic to ships on free roam. The values for the boundaries have to be calculated via radius
                //shipInstance.gameObject.AddComponent<EuclideanTorus>();
            }
        }


        /*Added try catch blocks so method does not hang.*/
        try
        {
            if (id == NetworkManager.NetworkInstance.socketManager.localId)
            {
                if (sceneName == "FreeRoamScene")
                {
                    shipInstance.UseFreeRoamController();
                }
                else if (sceneName == "RevolutionScene")
                {
                    shipInstance.UseRevolutionController();
                }

                Camera.main.GetComponent<CameraController>().setTarget(shipInstance.transform);
            }
        }
        catch (ArgumentNullException ex)
        {
            Debug.Log("No connection, using single player control set up for testing purposes.");
            Debug.Log(ex.Message);
            shipInstance.UseRevolutionController();

            Camera.main.GetComponent<CameraController>().setTarget(shipInstance.transform);
        }
    }

    //TODO No need to respawn in current game iteration. Possibly use in Free Roam mode?
    public void Respawn(GameObject RespawnedShip)
    {
        //Need to update server that ship was moved
        //RespawnedShip.transform.position = SpawnPosition;
        //RespawnedShip.transform.rotation = Quaternion.identity;
        //RespawnedShip.transform.Rotate(SpawnRotation);

        // Trying out transform RotateAround
        // RespawnedShip.transform.position = new Vector3(radius, 0, 0);
        // RespawnedShip.transform.rotation = Quaternion.identity;
        // RespawnedShip.transform.RotateAround(Vector3.zero, Vector3.back, -45);

    }


    //(Completed)Sync the Spawn position method with the instanstiate in Start method above
    //-----------------------------------------------------------------------
    //Returns Vectors to be used in the instantiation of the ship prefab. Index 0 is
    // position, index 1 is rotation
    //-----------------------------------------------------------------------
    public Vector3[] FindSpawnPosition(string sceneName)
    {
        if (sceneName == "FreeRoamScene")
        {
            //Fill in spawn position array and assign spawn position based off of PlayerID;
            //Temporary code:
            //SpawnPosition = new Vector3(0, 0, 0);
            //SpawnRotation = new Vector3(0, 0, 0);
        }
        else if (sceneName == "RevolutionScene")
        {

            //Assign Spawn position and Spawn rotation based off of id
            Vector3[,] Positions = new Vector3[8, 2]; //8 players max, for more players increase the array size

            Positions[0, 0] = new Vector3((radius * Mathf.Cos(0)), (radius * Mathf.Sin(0)), 0);
            Positions[0, 1] = new Vector3(0, 0, 90);

            Positions[1, 0] = new Vector3((radius * Mathf.Cos(45 * Mathf.Deg2Rad)), (radius * Mathf.Sin(45 * Mathf.Deg2Rad)), 0);
            Positions[1, 1] = new Vector3(0, 0, 135);

            Positions[2, 0] = new Vector3((radius * Mathf.Cos(90 * Mathf.Deg2Rad)), (radius * Mathf.Sin(90 * Mathf.Deg2Rad)), 0);
            Positions[2, 1] = new Vector3(0, 0, 180);

            Positions[3, 0] = new Vector3((radius * Mathf.Cos(135 * Mathf.Deg2Rad)), (radius * Mathf.Sin(135 * Mathf.Deg2Rad)), 0);
            Positions[3, 1] = new Vector3(0, 0, 225);

            Positions[4, 0] = new Vector3((radius * Mathf.Cos(180 * Mathf.Deg2Rad)), (radius * Mathf.Sin(180 * Mathf.Deg2Rad)), 0);
            Positions[4, 1] = new Vector3(0, 0, 270);

            Positions[5, 0] = new Vector3((radius * Mathf.Cos(225 * Mathf.Deg2Rad)), (radius * Mathf.Sin(225 * Mathf.Deg2Rad)), 0);
            Positions[5, 1] = new Vector3(0, 0, 315);

            Positions[6, 0] = new Vector3((radius * Mathf.Cos(270 * Mathf.Deg2Rad)), (radius * Mathf.Sin(270 * Mathf.Deg2Rad)), 0);
            Positions[6, 1] = new Vector3(0, 0, 0);

            Positions[7, 0] = new Vector3((radius * Mathf.Cos(315 * Mathf.Deg2Rad)), (radius * Mathf.Sin(315 * Mathf.Deg2Rad)), 0);
            Positions[7, 1] = new Vector3(0, 0, 45);

            Vector3[] SpawnPosition = new Vector3[2];
            SpawnPosition[0] = Positions[id, 0]; //Position
            SpawnPosition[1] = Positions[id, 1]; //Rotation to face center

            return (SpawnPosition);
        }
        return (null);
    }

    /*TODO This Method is most likely not needed. Ships are now instantiated.
      */
    public virtual void SpawnShip(Ship ship)
    {
        //this.Ship = ship;
        //this.Ship.UseRevolutionController();
        //transform.Rotate(new Vector3(0, 0, -180));
    }

}

