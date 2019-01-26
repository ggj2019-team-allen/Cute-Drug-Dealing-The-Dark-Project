using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour
{
    public bool active = false;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            text.color = new Color
            (
                Mathf.PingPong(Time.time, 1),
                Mathf.PingPong(Time.time + 0.5f, 1),
                Mathf.PingPong(Time.time + 1.0f, 1)
            );
        }
    }

    public void SetEffectActive(bool effect)
    {
        active = effect;
        if(!active)
        {
            text.color = Color.white;
        }
    }
}
