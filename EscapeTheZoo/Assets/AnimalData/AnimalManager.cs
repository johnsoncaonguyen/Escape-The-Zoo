using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InitBasedOnSelectedAnimal ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitBasedOnSelectedAnimal(){
		switch (Prefs.ActiveAnimal) {
		case Prefs.Animals.Hippo:
			Debug.Log ("Hippo Selected!");
			break;
		case Prefs.Animals.Elephant:
			Debug.Log ("Elephant Selected!");
			break;
		case Prefs.Animals.Croc:
			Debug.Log ("Croc Selected!");
			break;
		case Prefs.Animals.Giraffe:
			Debug.Log ("Giraffe Selected!");
			break;
		case Prefs.Animals.Lion:
			Debug.Log ("Lion Selected!");
			break;
		}
	}
}
