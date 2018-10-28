using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    AudioSource backgroundMusic;

    public bool loop;

	// Use this for initialization
	void Start () {
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.loop = loop;
        backgroundMusic.Play();
	}
	
	// Update is called once per frame
	void Update () {
        backgroundMusic.loop = loop;
	}
}
