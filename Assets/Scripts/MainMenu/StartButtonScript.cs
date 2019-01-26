using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class StartButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RainbowText rainbowText;
    public bool heldDown;
    public float holdTimer;
    public float maxHoldTime;

    void Update()
    {
        if(heldDown)
        {
            if(holdTimer >= maxHoldTime)
            {
                GameManager.instance.gameLoop.StartGame();
            }
            else
            {
                holdTimer += Time.deltaTime;
            }
        }
        else
        {
            if(holdTimer > 0.0f)
            {
                holdTimer -= Time.deltaTime;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        heldDown = true;
        rainbowText.SetEffectActive(heldDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        heldDown = false;
        rainbowText.SetEffectActive(heldDown);
    }
}
