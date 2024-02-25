using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float jumpTimes = 1.5f;
    public int jumpCooldown = 2;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private int canJumpCounter = 0;
    private int maxJumpCounter = 2;
    private bool isWallTouched = false;

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
        rb.velocity = new Vector2 (moveHorizontal * (isWallTouched ? 1 : speed), rb.velocity.y);
        
        if(moveHorizontal < 0 || moveHorizontal > 0) {
            rend.flipX = moveHorizontal < 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJumpCounter < maxJumpCounter)
        {
            rb.velocity = new Vector2 (0.0f, speed * jumpTimes);
            canJumpCounter += 1;
        }

    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJumpCounter = 0;
        }

        if (collision.gameObject.tag == "Wall")
        {
            isWallTouched = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWallTouched = false;
        }
    }
}
