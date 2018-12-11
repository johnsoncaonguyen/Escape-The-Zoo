using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour {


	private Animator anim;
	private Rigidbody rbody;
    private CharacterController controller;
    private Vector3 kickForce;
    private float inputH;
    private float inputV;
    private float realSpeed;
    private bool isGrounded;
    private bool kick;


    public float turnMaxSpeed = 30f;
    public float moveSpeed = 30f;
    public float sprintSpeed = 60f;


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        kick = false;
	}
	
	// Update is called once per frame
	void Update () {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (anim == null)
            fillAnimator();

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        anim.SetFloat("realSpeed", realSpeed);

        Debug.Log("RealSpeed: " + realSpeed);

        float moveX = inputH * turnMaxSpeed * Time.deltaTime;
        float moveZ = inputV * realSpeed * Time.deltaTime;

        //rbody.AddForce(new Vector3(0f, 0f, 10 * moveZ), ForceMode.Impulse);
        //rbody.AddTorque(new Vector3(10 * moveX, 0f, 0f), ForceMode.Impulse);

        //Debug.Log("MoveX: " + moveX);
        //Debug.Log("MoveZ: " + moveZ);

        /*transform.Rotate(0, moveX, 0);
        if (kick)
        {
            rbody.AddForce(new Vector3(0f, 0f, 1000 * -moveZ), ForceMode.Impulse);
            kick = false;
        }
        else
            transform.Translate(0, 0, moveZ);
            */
        rbody.velocity = Vector3.zero;
        rbody.angularVelocity = Vector3.zero;
        rbody.velocity = new Vector3(moveX, 0f, moveZ);
        rbody.MoveRotation(rbody.rotation * Quaternion.AngleAxis(inputH * Time.deltaTime * turnMaxSpeed, Vector3.up));
        rbody.MovePosition(rbody.position + this.transform.forward * inputV * Time.deltaTime * realSpeed);
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
    void LateUpdate()
    {
    }
    public void addKick(Vector3 f)
    {
        kick = true;
        kickForce = f;
    }
    void FixedUpdate()
    {

    }

    void fillAnimator(){
		GameObject animal = GetComponent<AnimalManager> ().GetActiveAnimal ();
		anim = animal.GetComponent<Animator>();	
	}
}
