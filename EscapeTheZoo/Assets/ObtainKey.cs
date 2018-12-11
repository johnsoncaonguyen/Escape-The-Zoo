using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainKey : MonoBehaviour {
    bool active = true;
    public bool onCop = false;
	// Use this for initialization
	void Start () {
        active = true;

	}

    // Update is called once per frame
    void Update()
    {
        if (!active)
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        else
        {
            if (!onCop) this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            else this.gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (active & other.tag == "Player")
        {
            GrabKey gc = other.gameObject.GetComponent<GrabKey>();
            NotificationScreen.getInstance().displayNotification("Obtained key to cage!", Time.time, 3);
            AudioManager.getInstance().playObtained();
            ScoreSystem.getInstance().addToScore(50, ScoreSystem.scType.NONE);
            gc.giveKey();
            active = false;
        }
    }
}
