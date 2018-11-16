using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionController : Controller {

    private Vector3 centerPoint;
    private readonly int radius = 5;

    public RevolutionController(Rigidbody2D rigidbody) {
        this.rigidbody = rigidbody;
        this.rigidbody.transform.Translate(new Vector3(0, radius, 0));
        this.rigidbody.transform.Rotate(new Vector3(180, 0, 0));
    }

    public override void Backward()
    {
        Debug.Log("You have no front facing thrusters");
    }

    public override void Forward()
    {
        Debug.Log("You have no back facing thrusters");
    }

    public override void Left()
    {
        rigidbody.transform.RotateAround(Vector3.zero, Vector3.forward, 20 * Time.deltaTime);
    }

    public override void Right()
    {
        rigidbody.transform.RotateAround(Vector3.zero, Vector3.back, 20 * Time.deltaTime);
    }
}
