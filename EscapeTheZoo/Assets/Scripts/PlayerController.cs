using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private string moveInputAxis = "Vertical"; // W & S Movement
    private string turnInputAxis = "Horizontal"; // A & D Movement
    private Vector3 jumpForce;

    public float rotationRate = 360;

    public float moveSpeed = 0.1f; // movement of 2 units per second
    public float jumpHeight = 2f;

    private float inputH;
    private float inputV;


    public Animator anim;
    public Rigidbody rb;



    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0, jumpHeight, 0);
    }


	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown("1"))
        //{
        //    anim.Play("Idle 2 Crocodile", -1, 0f); //Animation name, layer (-1 is base), 0f - 1f (Where it starts in the animation)
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);


        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed; //Sidewards
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed; //Forward/Backward
        transform.Translate(horizontalInput, 0f, verticalInput);       
        //float moveAxis = Input.GetAxis(moveInputAxis); // Value of 1 or negative 1, W is positive 1 and S is negative 1
        //float turnAxis = Input.GetAxis(turnInputAxis);
        //ApplyInput(moveAxis, turnAxis);

	}

}
