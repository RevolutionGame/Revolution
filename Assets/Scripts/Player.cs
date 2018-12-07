
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private uint id;
    public Ship shipPrefab;
    public Ship shipInstance;
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

    void Start () {

        //TODO Make Ship Prefab selection dynamic based on users selection or default 
        //-----------------------------------------------------------------------
        //Here The player ship is created using the selected Prefab, at radius 3
        //This still needs to be refined a bit. For now ship selection is preset
        //and the spawn position is still a bit iffy
        //-----------------------------------------------------------------------
        shipInstance = Instantiate(shipPrefab, new Vector3(0, -3, 0), transform.rotation);

        /*TODO This method hangs when no connection is made, add try/catch blocks
         where neccesary*/
        if (this.id == NetworkManager.NetworkInstance.socketManager.localId)
        {
            //shipInstance.gameObject.AddComponent<FreeRoamController>();
            //shipInstance.GetComponent<SpriteRenderer>().color = Color.red;
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


    //TODO Sync the Spawn position method with the instanstiate in Start method above
    //-----------------------------------------------------------------------
    //Update this method to determine the ships proper spaw and output it to a
    //variable that feeds into the vector3 argument in the ship instatiatiom 
    //method above. Ships should spawn in equally spaced increments around the 
    //circle. This ***EDIT THIS COMMENT AFTER THIS SECTION IS UPDATED***
    //-----------------------------------------------------------------------
    public void FindSpawnPosition()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "FreeRoamScene")
        {
            //Fill in spawn position array and assign spawn position based off of PlayerID;
            //Temporary code:
            //SpawnPosition = new Vector3(0, 0, 0);
            //SpawnRotation = new Vector3(0, 0, 0);
        }
        else if (sceneName == "RevolutionScene")
        {

            //Fill in spawn position array and assign spawn position based off of PlayerID;
            //Temporary code:
            //SpawnPosition = new Vector3(0, 0, 0);
            //SpawnRotation = new Vector3(0, 0, 0);

            //Assign Spawn position and Spawn rotation based off of Player ID
            /*
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
            */

        }
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
