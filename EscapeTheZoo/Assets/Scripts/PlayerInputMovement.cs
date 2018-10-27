using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour {

    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;

    private float movespeed = 40f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody = GetComponent<Rigidbody>();
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * movespeed * Time.deltaTime;
        float moveZ = inputV * movespeed * Time.deltaTime;

        //rbody.velocity = new Vector3(moveX, 0f, moveZ);
        rbody.AddForce(new Vector3(moveX, 0f, moveZ), ForceMode.VelocityChange);
	}
}
