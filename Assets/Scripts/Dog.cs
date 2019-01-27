using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    bool isPlayer = false;
    void OnTriggerEnter2D(Collider2D other)
    {
            isPlayer = true;
            other.GetComponent<PlayerController>().TriggeredSlow();
            isPlayer = false;
    }
}
