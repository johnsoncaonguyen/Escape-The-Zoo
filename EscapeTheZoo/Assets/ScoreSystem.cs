using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
    public float curScore { get; set; }
    float curModifier;
    public Text scoreText;
    public Text gameEndText;
    public TMPro.TextMeshProUGUI gameOverText;
    public enum scType {NONE, ROCKET, DONUT, PUNCH };
    scType type;
    static ScoreSystem instance;
    public static ScoreSystem getInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        curScore = 0;
        curModifier = 1;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Chaos Score : "+ (int)curScore;
        gameOverText.text = "Game Over \n Your Score : " + (int)curScore;
        gameEndText.text = "You escaped \n Your Score : " + (int)curScore;
    }

    public void addToScore(float val, scType mType)
    {
        if (mType == type & type != scType.NONE)
        {
            curModifier = 0.9f * curModifier;
            val = val * curModifier;
        }
        else if (mType != scType.NONE)
        {
            curModifier = 1.0f;
            type = mType;
        }
        curScore += val;
    }
}
