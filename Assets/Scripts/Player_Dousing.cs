using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dousing : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollide;
    private PlayerController pcl;
    
    public bool dousing = false;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        boxCollide = GetComponent<BoxCollider2D>();
        pcl = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<NPC_Doused>().isDoused == false)
        {
            if (other.gameObject.tag == "NPC")
            {
                anim.SetTrigger("Player_Dousing");
                rb2d.velocity = new Vector2(0, 0);
                dousing = true;
                StartCoroutine(Undouse());
            }
        }
    }

    public IEnumerator Undouse()
    {
        yield return new WaitForSeconds(0.5f);
        dousing = false;
    }
}
