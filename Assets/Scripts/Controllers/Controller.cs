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

    public void IncreaseThrust(int increasePercentage) {
        int increase = 1 + (increasePercentage / 100);
        thrust += (thrust * increase);
    }

    public void DecreaseThrust(int decrasePercentage) {
        int decrease = 1 + (decrasePercentage / 100);
        thrust -= (thrust * decrease);
    }

    public abstract void Forward();

    //public abstract void Forward(Rigidbody2D rigidbody);

    public abstract void Backward();

    public abstract void Right();

    public abstract void Left();

    
}
