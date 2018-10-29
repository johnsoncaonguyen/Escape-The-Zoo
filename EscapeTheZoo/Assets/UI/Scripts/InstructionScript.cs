using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public float time; //Seconds to read the text

    void Start()
    {
        Destroy(gameObject, time);
    }
}