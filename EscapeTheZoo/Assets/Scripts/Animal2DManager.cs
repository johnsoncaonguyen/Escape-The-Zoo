using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal2DManager : MonoBehaviour {

	public Image HippoFace, HippoFaceShaded, ElephantFace, ElephantFaceShaded;
	public Image CrocFace, CrocFaceShaded, GiraffeFace, GiraffeFaceShaded, LionFace, LionFaceShaded;

	private Image[] faces = new Image[8];

	// Use this for initialization
	void Start () {
		InitBasedOnSelectedAnimal ();
	}

	// Update is called once per frame
	void Update () {

	}

	void InitBasedOnSelectedAnimal(){
		//faces = new Image[8]{ };
		Image Face_i = HippoFace;
		Image Face_i_shaded = HippoFaceShaded;
		int index = 0;
		for (int i = 0; i < 5; i++) {
			switch (i) {
			case 0:
				Face_i = HippoFace;
				Face_i_shaded = HippoFaceShaded;
				break;
			case 1:
				Face_i = ElephantFace;
				Face_i_shaded = ElephantFaceShaded;
				break;
			case 2:
				Face_i = CrocFace;
				Face_i_shaded = CrocFaceShaded;
				break;
			case 3:
				Face_i = GiraffeFace;
				Face_i_shaded = GiraffeFaceShaded;
				break;
			case 4:
				Face_i = LionFace;
				Face_i_shaded = LionFaceShaded;
				break;
			}
			Face_i.gameObject.SetActive (false);

			if ((Prefs.Animals)i == Prefs.ActiveAnimal) {
				Face_i_shaded.gameObject.SetActive (false);
				continue;
			}

			faces [2*index] = Face_i;
			faces [2*index+1] = Face_i_shaded;

			index++;
		}

		for( int i = 0 ; i < faces.Length ; i+=2){
			RectTransform imgRect = faces[i].GetComponent<RectTransform> ();
			imgRect.anchoredPosition = new Vector2 (0, -i/2*60-30);

			imgRect = faces[i+1].GetComponent<RectTransform> ();
			imgRect.anchoredPosition = new Vector2 (0, -i/2*60-30);
		}
	}

	public void RescuedAnimal(Prefs.Animals animal){
		switch (animal) {
		case Prefs.Animals.Hippo:
			HippoFace.gameObject.SetActive(true);
			HippoFaceShaded.gameObject.SetActive(false);
			break;
		case Prefs.Animals.Elephant:
			ElephantFace.gameObject.SetActive(true);
			ElephantFaceShaded.gameObject.SetActive(false);
			break;
		case Prefs.Animals.Croc:
			CrocFace.gameObject.SetActive(true);
			CrocFaceShaded.gameObject.SetActive(false);
			break;
		case Prefs.Animals.Lion:
			LionFace.gameObject.SetActive(true);
			LionFaceShaded.gameObject.SetActive(false);
			break;
		case Prefs.Animals.Giraffe:
			GiraffeFace.gameObject.SetActive(true);
			GiraffeFaceShaded.gameObject.SetActive(false);
			break;
		}
	}

}
