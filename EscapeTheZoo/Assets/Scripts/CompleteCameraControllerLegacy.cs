using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCameraControllerLegacy : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start()
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate()
	{
		if (player == null)
		{
			Debug.LogWarning("Missing target ref !", this);
			return;
		}

		transform.position = player.transform.TransformPoint(offset / 2);
		transform.LookAt(player.transform);
	}
}
