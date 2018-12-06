using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

	public GameObject hippo, elephant, croc, giraffe, lion;

	private GameObject[] animals;
	private GameObject activeAnimal;

	// Use this for initialization
	void Start () {

		animals = new GameObject[5]{hippo, elephant, croc, giraffe, lion};

		InitBasedOnSelectedAnimal ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitBasedOnSelectedAnimal(){

		int animalIndex = 0;

		switch (Prefs.ActiveAnimal) {
		case Prefs.Animals.Hippo:
			Debug.Log ("Hippo Selected!");
			animalIndex = 0;
			break;
		case Prefs.Animals.Elephant:
			Debug.Log ("Elephant Selected!");
			animalIndex = 1;
			break;
		case Prefs.Animals.Croc:
			Debug.Log ("Croc Selected!");
			animalIndex = 2;
			break;
		case Prefs.Animals.Giraffe:
			Debug.Log ("Giraffe Selected!");
			animalIndex = 3;
			break;
		case Prefs.Animals.Lion:
			Debug.Log ("Lion Selected!");
			animalIndex = 4;
			break;
		}

		activeAnimal = animals [animalIndex];

		for (int i = 0; i < 5; i++)
			animals [i].SetActive (false);
		
		activeAnimal.SetActive (true);

	}

	public GameObject GetActiveAnimal(){
		return activeAnimal;
	}

}
