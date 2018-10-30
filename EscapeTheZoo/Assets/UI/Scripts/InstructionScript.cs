using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public GameObject instructionHUD; //Seconds to read the text
    int startTime;

    void Start()
    {
        startTime = (int)(Time.time);
    }

    private void Update()
    {
        startTime = (int)(Time.time);
        if (startTime == 8)
        {
            Animator instrAnimator = instructionHUD.GetComponent<Animator>();
            instrAnimator.Play("InstructionClip");
        }

    }
}