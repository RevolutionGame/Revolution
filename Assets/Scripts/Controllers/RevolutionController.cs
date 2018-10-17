using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionController : Controller {

    private Vector3 centerPoint;
    private int radius;

    RevolutionController(Rigidbody2D rigidbody) {
        this.rigidbody = rigidbody;
    }

    public override void Backward()
    {
        throw new System.NotImplementedException();
    }

    public override void Forward()
    {
        throw new System.NotImplementedException();
    }

    public override void Left()
    {
        throw new System.NotImplementedException();
    }

    public override void Right()
    {
        throw new System.NotImplementedException();
    }
}
