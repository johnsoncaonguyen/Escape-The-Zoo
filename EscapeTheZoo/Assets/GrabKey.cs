using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKey : MonoBehaviour {

    public int nKeys = 0;
	// Use this for initialization
	void Start () {
        nKeys = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void giveKey()
    {
        nKeys++;
    }
}
