using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Walk : MonoBehaviour
{
    public float speed;

	public Vector2 startDirection;
    private bool movingToEnd = true;

	public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(startDirection * speed * Time.deltaTime);

		spriteRenderer.flipX = startDirection.x >= 0.0f;
    }

	void OnTriggerExit2D(Collider2D other)
    {
		if(other.tag == "Waypoint")
		{
            if(movingToEnd == true)
            {
                transform.eulerAngles = new Vector3(0.0f, -180.0f * startDirection.x, 0.0f);
                movingToEnd = false;
            }
            else 
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                movingToEnd = true;
            }
		}
    }
}
