using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCollision : MonoBehaviour
{
    private BoxCollider2D boxCollide;

    // Start is called before the first frame update
    void Start()
    {
        boxCollide = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().catNip = 10;
        }
       if(other.gameObject.tag=="NPC")
        {
            Destroy(other.gameObject);
        }
     }
}
