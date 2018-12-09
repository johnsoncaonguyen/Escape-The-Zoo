using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainWeapon : MonoBehaviour {

    bool active = true;
    // Use this for initialization
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        else this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            Weapons wp = other.gameObject.GetComponent<Weapons>();
            print("Obtained the glove");
            wp.setActiveWeapon(Weapons.weapons.GLOVE);
            active = false;
        }
    }
}
