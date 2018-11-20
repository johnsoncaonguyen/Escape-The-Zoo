using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal2DManager : MonoBehaviour {

	public Image HippoFace, ElephantFace, CrocFace, GiraffeFace, LionFace;

	private Image[] Faces = new Image[4];

	// Use this for initialization
	void Start () {
		InitBasedOnSelectedAnimal ();
	}

	// Update is called once per frame
	void Update () {

	}



	void InitBasedOnSelectedAnimal(){
		int index = 0;
		for (int i = 0; i < 5; i++) {
			Image Face_i = HippoFace;
			switch (i) {
			case 1:
				Face_i = ElephantFace;
				break;
			case 2:
				Face_i = CrocFace;
				break;
			case 3:
				Face_i = GiraffeFace;
				break;
			case 4:
				Face_i = LionFace;
				break;
			}

			if ((Prefs.Animals)i == Prefs.ActiveAnimal) {
				Face_i.gameObject.SetActive (false);
				continue;
			}

			Faces [index] = Face_i;

			index++;
		}

		for( int i = 0 ; i < Faces.Length ; i++){
			RectTransform imgRect = Faces[i].GetComponent<RectTransform> ();
			imgRect.anchoredPosition = new Vector2 (0, -i*60-30);
		}
	}
}
