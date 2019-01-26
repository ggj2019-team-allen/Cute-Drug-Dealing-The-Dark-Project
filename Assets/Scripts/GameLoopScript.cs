using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopScript : MonoBehaviour
{
    float elapsedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The Game Loop has started!");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("Update: Elapsed Time is " + elapsedTime);
    }
}
