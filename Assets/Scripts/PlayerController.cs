using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private BoxCollider2D boxCollide;
    public float Xspeed = 5f;
    public float Yspeed = 5f;
    public float xMin, xMax, yMin, yMax;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private Player_Dousing pdouse;

    private bool dousing = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollide = GetComponent<BoxCollider2D>();
        pdouse = GetComponent<Player_Dousing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pdouse.dousing == false) 
        { 
            float movement = Input.GetAxis("Horizontal"); 
            float movementY = Input.GetAxis("Vertical"); 
            rigidBody.velocity = new Vector2(movement * Xspeed, movementY * Yspeed); 
 
            rigidBody.position = new Vector2
            (
                Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax)
            );
        }
    }
}
