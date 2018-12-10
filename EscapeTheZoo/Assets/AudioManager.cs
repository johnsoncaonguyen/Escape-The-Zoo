using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    static AudioManager instance;
    public AudioSource alert;
    public AudioSource slap;
    public AudioSource obtained;
    public AudioSource eat;
    public AudioSource woosh;
    public AudioSource plop;

    // Use this for initialization
    public static AudioManager getInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
    public void playAlert()
    {
        alert.Play();
    }
    public void playObtained()
    {
        obtained.Play();
    }
    public void playFire()
    {
        slap.Play();
    }
    public void playEat()
    {
        eat.Play();
    }
    public void playPlop()
    {
        plop.Play();
    }
    public void playWoosh()
    {
        woosh.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
