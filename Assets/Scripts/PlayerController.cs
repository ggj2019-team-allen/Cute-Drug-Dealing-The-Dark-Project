using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private BoxCollider2D boxCollide;
    public int catNip = 10;
    public float Xspeed = 5f;
    public float Yspeed = 5f;
    public float xMin, xMax, yMin, yMax;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private Player_Dousing pdouse;
    float movement = 0f;
    float movementY = 0f;
    public bool facingRight = true;
    public float slowTimer;
    public float maxslowTime;   
    float speedMultiplier = 1.0f;
    bool slowTriggered;
    bool slowed;
    
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
            movement = Input.GetAxis("Horizontal"); 
            movementY = Input.GetAxis("Vertical");
            

            anim.SetFloat("Speed", Mathf.Abs(movement));
            anim.SetFloat("SpeedY", Mathf.Abs(movementY));
            if (movement < 0 && facingRight) Flip();
            if (movement > 0 && !facingRight) Flip();

        }
        if(slowed == true)
        {
            if (slowTimer < maxslowTime)
            {
                slowTimer += Time.deltaTime;
            }
            else
            {
                slowed = false;
                speedMultiplier = 1.0f;
            }
        }
    }

    public void TriggeredSlow()
    {
        speedMultiplier = 0.1f;
        slowTimer = 0.0f;
        slowed = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void FixedUpdate()
    {
        if (pdouse.dousing == false)
        {
            rigidBody.velocity = new Vector2(movement * Xspeed * speedMultiplier, movementY * Yspeed * speedMultiplier);

            rigidBody.position = new Vector2
            (
                Mathf.Clamp(rigidBody.position.x, xMin, xMax), Mathf.Clamp(rigidBody.position.y, yMin, yMax)
            );
        }
    }
    
}
