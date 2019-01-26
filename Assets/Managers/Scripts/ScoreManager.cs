using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static ScoreManager instance = null;

    public int score;
    public int highScore;
    public int[] catsCount;
    public CatProfile[] scoreProfiles;

    // Delegates
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void OnValidate()
    {
        //Update array's size to match
        if (catsCount.Length != (int)CatType.TOTAL)
        {
            Array.Resize(ref catsCount, (int)CatType.TOTAL);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void AddScore(CatType type)
    {
        catsCount[(int)type] += 1;
        AddScore(GetScore(type));
    }

    public int GetScore(CatType type)
    {
        for(int i = 0; i < scoreProfiles.Length; ++i)
        {
            if(scoreProfiles[i].type == type)
            {
                return scoreProfiles[i].score;
            }
        }
        return 0;
    }

    public int RecordHighScore()
    {
        highScore = score;
        return highScore;
    }
}
