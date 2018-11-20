using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {


	public GameObject inGameMenu;
	public GameObject inGameHUD;
    public int startTime;
	public TextMeshProUGUI timerText;

	private bool gameRunning;

	// Use this for initialization
	void Start () {
		gameRunning = true;
        startTime = (int)(Time.time);

		AudioListener.volume = Prefs.GeneralVolume;
    }

    // Update is called once per frame
    void Update () {

		CheckForEscape ();

		UpdateTimer ();

	}

	void UpdateTimer(){

		//Debug.Log ("Elapsed Time: " + Time.time);
		int seconds = (int)(Time.time) - startTime;
		int minutes = seconds / 60;
		seconds -= minutes * 60;

		string secStr = (seconds >= 10) ? ""+seconds : "0" + seconds;
		string minStr = (minutes >= 10) ? ""+minutes : "0" + minutes;


		timerText.SetText (minStr+" : "+secStr);

	}

	void CheckForEscape(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Escape Pressed.");

			if (gameRunning) {
				Debug.Log ("Pausing Game and pulling up the in-game menu");
				Time.timeScale = 0;
			} else {
				Debug.Log ("Resuming Game and hiding the in-game menu");
				Time.timeScale = 1;
			}

			gameRunning = !gameRunning;
			UpdateUI ();
		}
	}

	void UpdateUI(){
		if (gameRunning) {
			inGameMenu.SetActive (false);
			inGameHUD.SetActive (true);
		} else {
			inGameMenu.SetActive (true);
			inGameHUD.SetActive (false);
		}
	}
}
