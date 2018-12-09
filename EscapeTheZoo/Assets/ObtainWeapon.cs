using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainWeapon : MonoBehaviour {

    bool active = true;
    public Weapons.weapons weaponType;
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
            print("Obtained the weapon");
            wp.setActiveWeapon(weaponType);
            active = false;
        }
    }
}
