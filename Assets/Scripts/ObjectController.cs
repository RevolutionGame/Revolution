using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour, ICollidable {

   public int MyDamage { get; set; }
   public int YourDamage { get; set; }

    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */
    public int ReciveDamage()
    {
        return 1;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag.Equals("Ship"))
        {
            //gameController.DestroyShip(collision.gameObject);
        }


    }*/
}
