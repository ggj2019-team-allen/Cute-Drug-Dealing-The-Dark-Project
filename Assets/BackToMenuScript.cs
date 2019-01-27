using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuScript : MonoBehaviour
{
    public float timer;
    public float maxTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            GameManager.instance.gameLoop.QuitGame();
        }
    }
}
