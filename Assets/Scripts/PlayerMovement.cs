using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    public float speed = 10.0f;
    public float jumpTimes = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        rb.velocity = new Vector2 (moveHorizontal * speed, rb.velocity.y);
        if(moveHorizontal < 0 || moveHorizontal > 0) {
            rend.flipX = moveHorizontal < 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2 (0.0f, speed * jumpTimes);
        }
    }
}
