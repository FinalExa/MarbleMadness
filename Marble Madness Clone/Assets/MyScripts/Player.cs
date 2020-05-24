using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    public float dragForceMax;
    public float dragForceMin;
    public Vector3 lastCheckpoint;
    public string state;
    public float timer;
    [SerializeField]
    float lastYPosition;
    [SerializeField]
    public float DeathByFallingDown;
    public float FallDamageOffset;
    public float FallTimer;
    public float MaxFallTimer;
    Renderer rend;
    bool movementEnabled;

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = new Vector3(5.65f, 25.5f, 14.04f);
        rb = GetComponent<Rigidbody>();
        state = "grounded";
        timer = 0;
        FallTimer = MaxFallTimer;
        rend = this.GetComponent<Renderer>();
        movementEnabled = true;
    }

    private void Update()
    {
        StateOperations();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovementHandler();
    }

    void StateOperations()
    {
        if (state == "grounded")
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                rb.drag = dragForceMin;
            }
            else
            {
                rb.drag = dragForceMax;
            }
        }
        else if (state == "airborne")
        {
            rb.drag = dragForceMin;
            if (timer < DeathByFallingDown)
            {
                timer += 1 * Time.deltaTime;
            }
            if (timer >= DeathByFallingDown)
            {
                Respawn();
            }
        }
    }

    void MovementHandler()
    {
        if (movementEnabled == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        state = "airborne";
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<VoidScript>() == null)
        {
            if (this.transform.position.y <= lastYPosition - FallDamageOffset)
            {
                RespawnByFallDamage();
            }
            else
            {
                lastYPosition = this.transform.position.y;
                state = "grounded";
                if (timer != 0)
                {
                    timer = 0;
                }
            }
        }
    }

    void Respawn()
    {
        timer = 0;
        transform.position = lastCheckpoint;
            lastYPosition = lastCheckpoint.y;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
    }

    void RespawnByFallDamage()
    {
        Color colorchange;
        timer = 0;
        if (FallTimer>0)
        {
            movementEnabled = false;
            FallTimer -= 1 * Time.deltaTime;
            colorchange = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 2, 1));
            rend.material.color = colorchange;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else if (FallTimer < 0)
        {
            FallTimer = 0;
        }
        else
        {
            rend.material.color = Color.white;
            FallTimer = MaxFallTimer;
            transform.position = lastCheckpoint;
            lastYPosition = lastCheckpoint.y;
            movementEnabled = true;
        }
    }
}