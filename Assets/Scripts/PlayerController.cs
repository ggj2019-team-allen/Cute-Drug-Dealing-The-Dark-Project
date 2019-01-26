using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float Xspeed = 5f;
    public float Yspeed = 5f;
    public float xMin, xMax, yMin, yMax;
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
        rigidBody.velocity = new Vector2(movement * Xspeed, movementY * Yspeed);

        rigidBody.position = new Vector2
        (
            Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax)
         );
 
    }
}
