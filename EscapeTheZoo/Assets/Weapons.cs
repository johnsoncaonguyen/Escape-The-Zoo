using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public enum weapons { NONE = -1, GLOVE = 0, ROCKET = 1, DONUT = 2 };
    // Use this for initialization
    weapons activeWeapon;
    public GameObject[] weaponModels;
    void Start () {
        activeWeapon = weapons.NONE;
	}

	public void setActiveWeapon(weapons weapon)
    {
        activeWeapon = weapon;
    }

    void fireGlove()
    {
        //get players current orientation and fire the glove in that direction
        weaponModels[(int)weapons.GLOVE].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        weaponModels[(int)weapons.GLOVE].transform.position = this.transform.position;
        weaponModels[(int)weapons.GLOVE].transform.rotation = this.transform.rotation * Quaternion.Euler(90, 0, 0);
        weaponModels[(int)weapons.GLOVE].GetComponentInChildren<GloveHit>().active = true;
        Rigidbody rb = weaponModels[(int)weapons.GLOVE].GetComponent<Rigidbody>();
        rb.velocity = 100 * this.transform.forward;
        print("setting position to " + this.transform.position);
        //setActiveWeapon(weapons.NONE);

    }
    void fireRocket()
    {
        //get players current position and place rocket there
        weaponModels[(int)weapons.ROCKET].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        weaponModels[(int)weapons.ROCKET].transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
        weaponModels[(int)weapons.ROCKET].GetComponent<Rigidbody>().velocity = Vector3.zero;
        weaponModels[(int)weapons.ROCKET].GetComponentInChildren<RocketHit>().active = true;
        print("setting position to " + this.transform.position);
        //setActiveWeapon(weapons.NONE);

    }
    void fireWeapon()
    {
        switch (activeWeapon)
        {
            case weapons.NONE:
                print("No active weapon to fire");
                break;
            case weapons.GLOVE:
                print("Firing glove");
                fireGlove();
                break;
            case weapons.ROCKET:
                print("Firing Rocket");
                fireRocket();
                break;
            case weapons.DONUT:
                print("Firing Donut");
                break;
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0))
            fireWeapon();

    }
}
