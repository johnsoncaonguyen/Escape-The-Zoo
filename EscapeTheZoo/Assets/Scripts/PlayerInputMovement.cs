﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour {

    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;

    public float turnMaxSpeed = 30f;
    public float moveSpeed = 0.1f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //rbody = GetComponent<Rigidbody>();
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * moveSpeed * Time.deltaTime;
        float moveZ = inputV * moveSpeed * Time.deltaTime;

        //rbody.velocity = new Vector3(moveX, 0f, moveZ);
        rbody.MoveRotation(rbody.rotation * Quaternion.AngleAxis(inputH * Time.deltaTime * turnMaxSpeed, Vector3.up));
        rbody.MovePosition(rbody.position + this.transform.forward * inputV * Time.deltaTime * moveSpeed);
        //rbody.AddForce(new Vector3(moveX, 0f, moveZ), ForceMode.VelocityChange);
    }
}
