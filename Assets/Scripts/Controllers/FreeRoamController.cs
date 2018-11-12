using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int speed = 10;
    public int rotationSpeed = 200;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float translattion = Input.GetAxis("Vertical") * speed * Time.deltaTime + 0.001f;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Translate(new Vector2(0, translattion));
        transform.Rotate(new Vector3(0, 0, rotation));
    }
}
