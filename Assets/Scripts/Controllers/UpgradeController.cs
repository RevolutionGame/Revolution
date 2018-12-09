using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : ObjectController {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().AddForce(transform.up * 25);
        GetComponent<Rigidbody2D>().angularVelocity = 90;
    }
	
	
	private void onTriggerEnter2D(Collider collision){

        if(collision.gameObject.tag.Equals("Ship"))
        {

        }
		
	}
}
