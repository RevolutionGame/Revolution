using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullController
{
    public override void Backward()
    {
        Debug.Log("No movemnet this is a null controller");
    }

    public override void Forward()
    {
        Debug.Log("No movemnet this is a null controller");
    }

    public override void Left()
    {
        Debug.Log("No movemnet this is a null controller");
    }

    public override void Right()
    {
        Debug.Log("No movemnet this is a null controller");
    }

}
