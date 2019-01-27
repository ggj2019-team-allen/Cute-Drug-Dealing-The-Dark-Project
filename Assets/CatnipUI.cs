using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatnipUI : MonoBehaviour
{
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(int catnipCount)
    {
        for(int i = 0; i < images.Length; ++i)
        {
            images[i].SetActive((i + 1) <= catnipCount); 
        }
    }
}
