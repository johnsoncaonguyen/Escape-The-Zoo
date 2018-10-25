using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReporter : MonoBehaviour {

    public Vector3 prevPos;
    public Vector3 Velocity
    {
        get;
        private set;
    }
    // Use this for initialization
    void Start()
    {
        prevPos = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Velocity = (this.transform.position - prevPos) / Time.deltaTime;
        prevPos = this.transform.position;
    }
}
