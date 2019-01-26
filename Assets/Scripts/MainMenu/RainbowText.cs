using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour
{
    public bool active = false;
    public Text text;
    public Color origColor;
    private float randomStart;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        origColor = text.color;
        randomStart = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            text.color = new Color
            (
                Mathf.PingPong(Time.time + randomStart, 1),
                Mathf.PingPong(Time.time + randomStart + 0.5f, 1),
                Mathf.PingPong(Time.time + randomStart + 1.0f, 1)
            );
        }
    }

    public void SetEffectActive(bool effect)
    {
        active = effect;
        if(!active)
        {
            text.color = origColor;
        }
    }
}
