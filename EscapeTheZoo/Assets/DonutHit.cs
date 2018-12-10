using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutHit : MonoBehaviour {
    public bool active = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!active)
        {
            this.transform.localScale = Vector3.zero;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        print("Collided with " + other);
        if (active && other.gameObject.tag == "Guard")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            print("Obtained the rigidbody of cop");
            other.gameObject.GetComponent<AICop>().setState(AICop.AIStates.Eating);
            //rb.AddTorque(totalForce, ForceMode.Impulse);
            active = false;
            
            NotificationScreen.getInstance().displayNotification("NEWSFLASH : Diabetes on the rise in Zoo Guards!", Time.time + 1, 3);
        }
    }

}
