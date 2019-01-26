using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour
{
    float elapsedTime;
    bool executed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The Game Loop has started!");
        SoundManager.instance.PlayBGM(BGMAudioID.InGameMusic);
        SoundManager.instance.PlaySFXLooping(SFXAudioID.Meow1);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("Update: Elapsed Time is " + elapsedTime);

        if(elapsedTime >= 10.0f && !executed)
        {
            SoundManager.instance.StopSFX(SFXAudioID.Meow1);
            SoundManager.instance.PlayBGM(BGMAudioID.MenuMusic);
            executed = true;
        }
    }
}
