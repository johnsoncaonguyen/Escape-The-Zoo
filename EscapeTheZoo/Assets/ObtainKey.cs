using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainKey : MonoBehaviour {
    bool active = true;
	// Use this for initialization
	void Start () {
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!active)
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        else this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            GrabKey gc = other.gameObject.GetComponent<GrabKey>();
            print("Collided with key");
            gc.giveKey();
            active = false;
        }
    }
}
