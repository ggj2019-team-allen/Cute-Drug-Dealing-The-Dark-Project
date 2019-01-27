using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Data : MonoBehaviour
{
    public CatType type;
    public SpriteRenderer bodySpRend;
    public Animator anim;

    public void Initialize(CatType newType)
    {
        type = newType;
        anim.SetInteger("Type", (int)newType);
        //bodySpRend.sprite = GameManager.instance.gameLoop.GetCatSprite(type);
    }
}
