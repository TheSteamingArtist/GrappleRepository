using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float leftSpeed;

    public float rightSpeed;

    public float jumpSpeed;

    public int JumpCount = 0;

    public int MaximumAmountOfJumps = 1;

    public Rigidbody rb;

    public Collider playerCollider;

    public GameObject player;

    public int buttonPressLimit = 1;

    public int buttonPressAdder;

    private bool isMovingLeft;

    private bool isMovingRight;

    private bool isMovingUp = false;

    private bool isColliding = true;

    void Start()
    {

        JumpCount = MaximumAmountOfJumps - 1;

        player = GameObject.Find("Player");

        playerCollider = player.GetComponent<Collider>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.W))
        {
            if (JumpCount > 0)
            {
                rb.velocity = transform.up * 10;
                JumpCount -= 1;
            }
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
            rb.velocity = transform.up * 10;
            JumpCount -= 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
     
        if(collision.gameObject.tag == "Floor")
        {
            JumpCount = JumpCount + 1;
        }

    }
}

