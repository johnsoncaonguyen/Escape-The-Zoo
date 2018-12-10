using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{
	public float distance_from_player;
	public float camera_height;
	public GameObject player;

	private Vector3 offset;
	private float horizontal_angle;
	private float vertical_angle;
	private float turnSpeed = 2f;
	private float cameraInertia = 1.05f;

	void Start()
	{
		horizontal_angle = 0;
		vertical_angle = 0;
	}

	void LateUpdate()
	{
		if (Input.GetMouseButton (1))// || Input.GetMouseButton (1)) 
		{
			horizontal_angle += Input.GetAxis ("Mouse X") * turnSpeed;
			vertical_angle -= Input.GetAxis ("Mouse Y") * turnSpeed;

			vertical_angle = Mathf.Clamp (vertical_angle, 10-camera_height, 80 - camera_height);
			//horizontal_angle = Mathf.Clamp (horizontal_angle, -180, 180);
				
			//Debug.Log ("Angles: " + horizontal_angle +", " + vertical_angle);
		}
		else
		{
			horizontal_angle /= cameraInertia;
	    	vertical_angle /= cameraInertia;
		}

		Vector3 centerOfMass = player.transform.position + new Vector3 (0, 2, 0);

		Vector3 forwardV = Quaternion.AngleAxis(horizontal_angle, Vector3.up) * player.transform.forward;

		forwardV = Quaternion.AngleAxis (camera_height + vertical_angle, Vector3.Cross (Vector3.up, forwardV)) * forwardV; 

		transform.position = player.transform.position - distance_from_player * forwardV ;

		//we want the camera to look at the center of mass of the character, not its legs
		transform.LookAt (centerOfMass);

		//offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * turnSpeed, Vector3.up) * offset;
		//transform.position = player.transform.position + offset;
		//transform.LookAt (player.transform.position);

	}
}