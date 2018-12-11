using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoRescue : MonoBehaviour {
    Animation anim;
    bool rescued = false;
    public enum ANIMALS { HIPPO, LION, GIRAFFE, CROCODILE}
    public ANIMALS animal = ANIMALS.HIPPO;
    // Use this for initialization
    float rescueTime;
	void Start () {
        anim = this.GetComponent<Animation>();
        rescued = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(rescued)
        {
            if (rescueTime + 10 < Time.time)
                this.transform.localScale = new Vector3(0f,0f,0f);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        print("Collided with " + other);
        if (other.gameObject.tag == "Player" & !rescued)
        {
            rescueTime = Time.time;
            rescued = true;
            ScoreSystem.getInstance().addToScore(100, ScoreSystem.scType.NONE);

            switch (animal)
            {
                case ANIMALS.HIPPO:
                    print("Rescued Hippo");
                    anim.Play("Success Hippo");
                    NotificationScreen.getInstance().displayNotification("Thanks for rescuing me! Here is something to help you. I was working on this in my time in the cage.", Time.time, 5);
                    break;
                case ANIMALS.CROCODILE:
                    print("Rescued Croc");
                    anim.Play("Success Crocodile");
                    NotificationScreen.getInstance().displayNotification("Thanks for rescuing me! Here is something to help you. I stole this from one of the guards.", Time.time, 5);
                    break;
                case ANIMALS.GIRAFFE:
                    print("Rescued Hippo");
                    anim.Play("Success Giraffe");
                    NotificationScreen.getInstance().displayNotification("Thanks for rescuing me! I have nothing to give you.", Time.time, 5);
                    break;
                case ANIMALS.LION:
                    print("Rescued Hippo");
                    anim.Play("Success Hippo");
                    NotificationScreen.getInstance().displayNotification("ROAR! Thanks for rescuing me! Here is something to help you. It dropped out of the sky.", Time.time, 5);
                    break;
            }
        }
    }
}
