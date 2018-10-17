using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : Controller
{
    public FreeRoamController(Rigidbody2D rigidbody) {
        this.rigidbody = rigidbody;
    }

    public override void Backward()
    {
        Debug.Log("You have no front facing thrusters");
    }

    public override void Forward()
    {
        this.rigidbody.AddForce(this.rigidbody.transform.up * Thrust);
    }

    public override void Left()
    {
        this.rigidbody.transform.Rotate(Vector3.forward * Torque);
    }
    public override void Right()
    {
        this.rigidbody.transform.Rotate(Vector3.back * Torque);
    }
}
