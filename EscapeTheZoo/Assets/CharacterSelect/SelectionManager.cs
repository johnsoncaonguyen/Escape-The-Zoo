using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {

	//Add them from left to right - could potentially be done automatically (calculate mean etc..)
	public GameObject Hippo, Elephant, Croc, Giraffe, Lion;

	public GameObject selectionRing;

	private int num_animals, curr_index;

	// Use this for initialization
	void Start () {
		num_animals = 5;
		curr_index = (int)Prefs.DefaultAnimal;
		SetRingToCurrentAnimal ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp(KeyCode.Return)) {
			Select ();
			
		} else if (Input.GetKeyUp ("right")) {			
			curr_index = (curr_index + 1) % num_animals;
			SetRingToCurrentAnimal();

		} else if (Input.GetKeyUp ("left")) {
			curr_index = (curr_index == 0)?num_animals-1:curr_index-1;
			SetRingToCurrentAnimal ();

		}
	}

	private void SetRingToCurrentAnimal(){
		Prefs.Animals curr_animal = (Prefs.Animals)curr_index;

		GameObject curr_animal_object = Hippo;
		switch (curr_animal) {
		case Prefs.Animals.Elephant:
			curr_animal_object = Elephant;
			break;
		case Prefs.Animals.Croc:
			curr_animal_object = Croc;
			break;
		case Prefs.Animals.Giraffe:
			curr_animal_object = Giraffe;
			break;
		case Prefs.Animals.Lion:
			curr_animal_object = Lion;
			break;
		}

		selectionRing.transform.position = new Vector3(curr_animal_object.transform.position.x , 
			selectionRing.transform.position.y , curr_animal_object.transform.position.z);
	}

	public void Select(){
		Debug.Log ("Animal Selected.");
		Prefs.ActiveAnimal = (Prefs.Animals)curr_index;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
