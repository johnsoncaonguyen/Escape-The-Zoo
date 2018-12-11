using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour {
    public TMPro.TextMeshProUGUI[] scoreTexts;
	// Use this for initialization
	void Start () {
        GameData gd = new GameData();
        gd.Load();
        float[] arr = gd.scores.ToArray();
        for ( int i = 0; i < arr.Length; i++)
        {
            scoreTexts[i].text = arr[i].ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
