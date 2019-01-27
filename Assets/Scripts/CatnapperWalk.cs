using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CatnapperWalk : MonoBehaviour
{
    private BoxCollider2D boxCollide;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private bool lost = false;
    

    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollide = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lost == false)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lost = true;
            Destroy(other.gameObject);
            anim.SetTrigger("Capture");
            StartCoroutine(GameOver());
            

        }
        else if (other.gameObject.tag == "NPC")
        {
            Destroy(other.gameObject);
            SpawnerScript.instance.spawnCount -= 1;
            
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
}
