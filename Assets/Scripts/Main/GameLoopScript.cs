using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopScript : MonoBehaviour
{
    float elapsedTime;

    [Header("Levels")]
    public string gameSceneName;
    public string menuSceneName;

    bool gameStarted;

    [Header("Testing")]
    public GameObject[] catPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The Game Loop has started!");
        SoundManager.instance.PlayBGM(BGMAudioID.MenuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Update: Elapsed Time is " + elapsedTime);

        if(gameStarted)
        {
            //Test Logic of Color Cats Scoring
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ScoreManager.instance.AddScore(CatType.Orange);
                Instantiate
                (
                    catPrefabs[0],
                    new Vector3
                    (
                        Random.Range(-9.0f, 9.0f), 
                        Random.Range(-3.0f, 3.0f), 
                        0.0f
                    ),
                    Quaternion.identity
                );
                SoundManager.instance.PlaySFXOneShot(SFXAudioID.Meow1);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ScoreManager.instance.AddScore(CatType.White);
                Instantiate
                (
                    catPrefabs[1],
                    new Vector3
                    (
                        Random.Range(-9.0f, 9.0f), 
                        Random.Range(-3.0f, 3.0f), 
                        0.0f
                    ),
                    Quaternion.identity
                );
                SoundManager.instance.PlaySFXOneShot(SFXAudioID.Meow1);
            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                ScoreManager.instance.AddScore(CatType.ThreeColor);
                Instantiate
                (
                    catPrefabs[2],
                    new Vector3
                    (
                        Random.Range(-9.0f, 9.0f), 
                        Random.Range(-3.0f, 3.0f), 
                        0.0f
                    ),
                    Quaternion.identity
                );
                SoundManager.instance.PlaySFXOneShot(SFXAudioID.Meow1);
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting the game...");
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        gameStarted = true;
        SoundManager.instance.PlayBGM(BGMAudioID.InGameMusic);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        ScoreManager.instance.RecordHighScore();
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
        gameStarted = false;
        SoundManager.instance.PlayBGM(BGMAudioID.MenuMusic);
    }
}
