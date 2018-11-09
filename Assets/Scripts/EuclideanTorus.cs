using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus: MonoBehaviour {

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

	// Update is called once per frame
	void Update () {

        Vector2 newPos = transform.position;

        // Teleport the game object
        if (transform.position.y > screenTop)
        {

            newPos.y = screenBottom;

        }
        else if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        else if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }

        else if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        transform.position = newPos;
    }
}

