using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour {
    public bool active = false;
    float flyTime;
    bool isFlying = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFlying)
        {
            flyTime += Time.deltaTime;
            if (flyTime > 5)
            {
                //stop flying
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
                isFlying = false;
            }
        }
	}
    void OnTriggerEnter(Collider other)
    {
        print("Collided with " + other);
        if (active)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            print("Obtained the rigidbody of cop");
            other.gameObject.GetComponent<AICop>().setState(AICop.AIStates.Flying);
            Vector3 totalForce = new Vector3(0, 500, 0);
            print("Total force added " + totalForce);
            rb.AddForce(totalForce, ForceMode.Impulse);
            //rb.AddTorque(totalForce, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().AddForce(totalForce, ForceMode.Impulse);
            this.GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<AudioSource>().Play();
            active = false;
            isFlying = true;
            flyTime = 0;
        }
    }
}
