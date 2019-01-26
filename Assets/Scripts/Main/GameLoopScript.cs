using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopScript : MonoBehaviour
{
    float elapsedTime;
    bool executed = false;

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
            if(ScoreManager.instance.score >= 1000 && !executed)
            {
                SoundManager.instance.PlayBGM(BGMAudioID.MenuMusic);
                executed = true;
            }

            //Test Logic of Color Cats Scoring
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ScoreManager.instance.AddScore(CatType.Orange);
                Instantiate
                (
                    catPrefabs[0],
                    new Vector3
                    (
                        Random.Range(-5.0f, 5.0f), 
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
                        Random.Range(-5.0f, 5.0f), 
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
                        Random.Range(-5.0f, 5.0f), 
                        Random.Range(-3.0f, 3.0f), 
                        0.0f
                    ),
                    Quaternion.identity
                );
                SoundManager.instance.PlaySFXOneShot(SFXAudioID.Meow1);
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        gameStarted = true;
        SoundManager.instance.PlayBGM(BGMAudioID.InGameMusic);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
        gameStarted = false;
        SoundManager.instance.PlayBGM(BGMAudioID.MenuMusic);
    }
}
