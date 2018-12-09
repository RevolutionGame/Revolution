using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : ObjectController {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().AddForce(transform.up * 25);
        GetComponent<Rigidbody2D>().angularVelocity = 90;
        Destroy(gameObject, 30);
    }
	
	
	private void OnTriggerEnter2D(Collider2D collision){
        //Upon pick up upgrades, increases upgrade level, which will decide which bullet is fired.
        if (collision.gameObject.tag.Equals("Ship"))
        {
            collision.gameObject.GetComponent<Ship>().upgradeLevel++;
            Destroy(gameObject);
        }
        
	}
}
