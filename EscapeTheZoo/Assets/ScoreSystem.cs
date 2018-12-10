using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
    float curScore;
    float curModifier;
    public Text scoreText;
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
        scoreText.text = "Chaos Score : "+curScore;
        gameOverText.text = "Game Over \n Your Score :" + curScore;
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
