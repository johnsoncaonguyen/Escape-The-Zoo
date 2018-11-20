using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs {

	public enum Animals{
		Hippo,
		Elephant,
		Croc,
		Giraffe,
		Lion
	};

	public static Animals ActiveAnimal = Animals.Elephant;

	public static Animals DefaultAnimal = Animals.Elephant;

	public static float GeneralVolume = 1.0f;

}
