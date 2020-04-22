using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    public float dragForceMax = 1;
    public float dragForceMin = 0.5f;
    public Vector3 lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = new Vector3(5.65f, 25.5f, 14.04f);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
        {
            rb.drag = dragForceMin;
        }
        else
        {
            rb.drag = dragForceMax;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }
}