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
        if (collider.gameObject.tag == "Player" && doorController.IsDoorClosed) // this string is your newly created tag
        {
            GrabKey gc = collider.gameObject.GetComponent<GrabKey>();
            if (gc.nKeys > 0)
            {
                print("Opening the door");
                doorController.OpenDoor();
                gc.nKeys--;
            }
            else
            {
                PlayerInputMovement rb = collider.gameObject.GetComponent<PlayerInputMovement>();
                Vector3 force = 10000 * Vector3.one; //this.transform.up;
                rb.addKick(force);
                NotificationScreen.getInstance().displayNotification("You must find the key to the cage!", Time.time, 3);
                print("Can't open the door");
            }
        }
	}
}
