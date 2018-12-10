using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour {


	private Animator anim;
	private Rigidbody rbody;
    private CharacterController controller;

    private float inputH;
    private float inputV;
    private bool isGrounded;



    public float turnMaxSpeed = 30f;
    public float moveSpeed = 30f;
    public float sprintSpeed = 60f;
    public float velocityY = 0f;
    public float gravity = -5.0f;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody = GetComponent<Rigidbody>();
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (anim == null)
            fillAnimator();

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float realSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        float moveX = inputH * turnMaxSpeed * Time.deltaTime;
        float moveZ = inputV * realSpeed * Time.deltaTime;

        Debug.Log("Force: " + new Vector3(0f, 0f, moveZ));
        Debug.Log("Torque: " + new Vector3(moveX, 0f, 0f));
        rbody.AddForce(new Vector3(0f, 0f, 1000 * moveZ), ForceMode.Impulse);
        rbody.AddTorque(new Vector3(1000 * moveX, 0f, 0f), ForceMode.Impulse);

        //Debug.Log("MoveX: " + moveX);
        //Debug.Log("MoveZ: " + moveZ);

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
        //rbody.velocity = new Vector3(moveX, 0f, moveZ);
        //rbody.MoveRotation(rbody.rotation * Quaternion.AngleAxis(inputH * Time.deltaTime * turnMaxSpeed, Vector3.up));
        //rbody.MovePosition(rbody.position + this.transform.forward * inputV * Time.deltaTime * moveSpeed);
        //rbody.AddForce(new Vector3(moveX, 0f, moveZ), ForceMode.VelocityChange);
        //velocityY += gravity * Time.deltaTime;

        //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //input = input.normalized;

        //Vector3 temp = Vector3.zero;
        //if (input.z == 1)
        //{
        //    temp += transform.forward;
        //}
        //else if (input.z == -1)
        //{
        //    temp += transform.forward * -1;
        //}

        //if (input.x == 1)
        //{
        //    temp += transform.right;
        //}
        //else if (input.x == -1)
        //{
        //    temp += transform.right * -1;
        //}

        //Vector3 velocity = temp * speed;
        //velocity.y = velocityY;

        //controller.Move(velocity * Time.deltaTime);

        //if (controller.isGrounded)
        //{
        //    velocityY = 0;
        //}
    }

    void FixedUpdate()
    {

    }

    void fillAnimator(){
		GameObject animal = GetComponent<AnimalManager> ().GetActiveAnimal ();
		anim = animal.GetComponent<Animator>();	
	}
}
