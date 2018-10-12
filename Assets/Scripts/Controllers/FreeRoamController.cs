using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : Controller
{
    public override void Backward(Rigidbody2D rigidbody)
    {
        rigidbody.AddForce(-rigidbody.transform.up * Thrust);
    }

    public override void Forward(Rigidbody2D rigidbody)
    {
        rigidbody.AddForce(rigidbody.transform.up * Thrust);
    }

    public override void Left(Rigidbody2D rigidbody)
    {
        rigidbody.AddTorque(Torque);
    }

    public override void Right(Rigidbody2D rigidbody)
    {
        rigidbody.AddTorque(-Torque);
    }
}
