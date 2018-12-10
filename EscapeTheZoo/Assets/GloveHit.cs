using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHit : MonoBehaviour {
    public bool active;
	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        print("Collided with " + other);
        if (active && other.gameObject.tag == "Guard")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            print("Obtained the rigidbody of cop");
            other.gameObject.GetComponent<AICop>().setState(AICop.AIStates.Flying);
            Vector3 totalForce = 4 * this.GetComponent<Rigidbody>().velocity + new Vector3(0, 500, 0);
            Vector3 totalTorque = new Vector3(100, 100, 100);
            print("Total force added " + totalForce);
            rb.AddForce(totalForce, ForceMode.Impulse);
            rb.AddTorque(totalTorque, ForceMode.Impulse);
            other.gameObject.GetComponent<AudioSource>().Play();
            active = false;
        }
    }
}
