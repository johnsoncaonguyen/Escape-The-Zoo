using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInteractionController : MonoBehaviour {

	public BrokenVector.LowPolyFencePack.DoorController doorController;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("Trigger Enter! "+collider.gameObject.tag);
		if(collider.gameObject.tag == "Player") // this string is your newly created tag
		{
			doorController.OpenDoor ();
		}
	}
}
