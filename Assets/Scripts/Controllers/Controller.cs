using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller {

    protected Rigidbody2D rigidbody;
    private float thrust = .25f;
    private float torque = 1f;

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

    public abstract void Forward();

    public abstract void Backward();

    public abstract void Left();

    public abstract void Right();
}
