using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
public class SimpleMovement : MonoBehaviour {

    private Animator anim;
    private Rigidbody rbody;
    private bool isGrounded = true;

    public float forwardMaxSpeed = 1f;
    public float turnMaxSpeed = 1f;
    public int jumpHeight = 35;

    void Awake()
    {
        anim = GetComponent<Animator>();

        rbody = GetComponent<Rigidbody>();

        isGrounded = true;
    }

    void Update()
    {
        Vector3 jumpForce = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = new Vector3(0, jumpHeight, 0);
            Debug.Log("JumpForce: " + jumpForce);
            isGrounded = false;
        }
        
        rbody.AddForce(jumpForce);
        anim.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        float inputForward = 0f;
        float inputTurn = 0f;
        

        

        inputTurn = Input.GetAxis("Horizontal");
        inputForward = Input.GetAxis("Vertical");



        
        rbody.MovePosition(rbody.position + this.transform.forward * inputForward * Time.deltaTime * forwardMaxSpeed);
        rbody.MoveRotation(rbody.rotation * Quaternion.AngleAxis(inputTurn * Time.deltaTime * turnMaxSpeed, Vector3.up));

        anim.SetFloat("velForward", inputForward);
        anim.SetFloat("velTurn", inputTurn);

        Debug.Log("MaxHeight: " + transform.position.y);
        isGrounded = false;
    }

    //This is a physics callback
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}
