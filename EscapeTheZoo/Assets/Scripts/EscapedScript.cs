using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscapedScript : MonoBehaviour {

    bool winGame = false;
    int startTime;
    public GameObject winGameHud;
    int winGameTime;
	// Use this for initialization
	void Start () {
        winGame = false;
        startTime = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (winGame)
        {
            print(Time.time - winGameTime);
            if ((int)Time.time - winGameTime > 3)
            {
                print("Shifting scene now");
                SceneManager.LoadScene("MainMenu");
                winGame = false;
                return;
            }
            return;
        }
    }


    private void endGame()
    {
        winGame = true;
        winGameTime = (int)Time.time;
        Animator youEscaped = winGameHud.GetComponent<Animator>();
        int bonusScore = 5 * Mathf.Max(0, 10 - (winGameTime - startTime) / 60);
        Debug.Log(bonusScore);
        ScoreSystem.getInstance().addToScore(200 + bonusScore, ScoreSystem.scType.NONE);
        youEscaped.Play("WinGameClip");
        GameData gd = new GameData();
        gd.Load();
        gd.updateScore(ScoreSystem.getInstance().curScore);
        gd.Save();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TouchMeCube")
        {
            endGame();
        }
    }
}
