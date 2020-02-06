using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float leftSpeed;

    public float rightSpeed;

    public float jumpSpeed;

    public Rigidbody rb;

    public Collider playerCollider;

    public GameObject player;

    private bool isMovingLeft;

    private bool isMovingRight;

    private bool isMovingUp = false;

    private bool isColliding = true;

    void Start()
    {
        player = GameObject.Find("Player");

        playerCollider = player.GetComponent<Collider>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.W))
        {
            isMovingUp = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isMovingLeft = true;

        }
        else
        {
            isMovingLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            isMovingRight = true;
        }
        else
        {
            isMovingRight = false;
        }
    }

    void FixedUpdate()
    {
        if (isMovingLeft == true)
        {
            transform.position = transform.position + new Vector3(-leftSpeed, 0, 0);
        }

        if (isMovingRight == true)
        {
            transform.position = transform.position + new Vector3(rightSpeed, 0, 0);
        }

        if (isMovingUp == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed);

            isMovingUp = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision jumpingHere)
    {
        if (jumpingHere.gameObject.tag == "Floor")
        {
            isColliding = false;
        }
    }
}
