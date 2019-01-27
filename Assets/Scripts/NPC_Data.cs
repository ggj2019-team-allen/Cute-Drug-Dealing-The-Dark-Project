using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Data : MonoBehaviour
{
    public CatType type;
    public SpriteRenderer bodySpRend;

    public void Initialize(CatType newType)
    {
        type = newType;
        bodySpRend.sprite = GameManager.instance.gameLoop.GetCatSprite(type);
    }
}
