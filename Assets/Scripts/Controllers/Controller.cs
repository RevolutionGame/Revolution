using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller {
    private float thrust = 1f;
    private float torque = .25f;

    public float Thrust
    {
        get { return thrust; }
        set { thrust = value; }
    }

    public float Torque
    {
        get { return torque; }
        set { torque = value; }
    }

    public abstract void Forward(Rigidbody2D rigidbody);

    public abstract void Backward(Rigidbody2D rigidbody);

    public abstract void Left(Rigidbody2D rigidbody);

    public abstract void Right(Rigidbody2D rigidbody);
}
