using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreListener : MonoBehaviour
{
    public Text highScoreDisplayText;
    public Text lastScoreDisplayText;
    public Text highScoreText;
    public Text lastScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplayText.text = String.Format ("{0:00000000}", ScoreManager.instance.highScore);
        lastScoreDisplayText.text = String.Format ("{0:00000000}", ScoreManager.instance.score);

        if(ScoreManager.instance.highScore <= 0)
        {
            highScoreText.enabled = false;
            highScoreDisplayText.enabled = false;
        }
        if(ScoreManager.instance.score <= 0)
        {
            lastScoreText.enabled = false;
            lastScoreDisplayText.enabled = false;
        }
    }
}
