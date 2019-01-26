using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PixelTextFix : MonoBehaviour
{
    public Font font;
    
    void Update()
    {
        if(font)
            font.material.mainTexture.filterMode = FilterMode.Point;
    }
}
