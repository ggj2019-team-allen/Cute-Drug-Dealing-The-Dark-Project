using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCatNapper : MonoBehaviour
{
    private BoxCollider2D boxcollide;
    public CatnapperSpawner napspawn;
    // Start is called before the first frame update
    void Start()
    {
        boxcollide = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Catnapper")
        {
            Destroy(other.gameObject);
            napspawn.spawnCount -= 1;

        }
    }
}
