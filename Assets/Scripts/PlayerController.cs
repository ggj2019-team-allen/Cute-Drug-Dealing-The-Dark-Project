using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Xspeed = 5f;
   public float Yspeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        //float movementVertical = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector2(movement * Xspeed, movementY * Yspeed);
 
    }
}
