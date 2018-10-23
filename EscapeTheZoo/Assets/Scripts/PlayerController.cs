using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private string moveInputAxis = "Vertical"; // W & S Movement
    private string turnInputAxis = "Horizontal"; // A & D Movement

    public float rotationRate = 360;

    public float moveSpeed = 0.1f; // movement of 2 units per second

    void Start ()
    {

    }


	// Update is called once per frame
	void Update () {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(horizontalInput, 0f, verticalInput);       
        //float moveAxis = Input.GetAxis(moveInputAxis); // Value of 1 or negative 1, W is positive 1 and S is negative 1
        //float turnAxis = Input.GetAxis(turnInputAxis);
        //ApplyInput(moveAxis, turnAxis);

	}

}
