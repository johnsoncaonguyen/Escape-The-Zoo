using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScreen : MonoBehaviour {

    public Text textBox;
    static WeaponScreen instance;
    // Use this for initialization
    public static WeaponScreen getInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        textBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayWeaponText(string msg)
    {
        textBox.text = "Active Weapon : " + msg;
    }
}
