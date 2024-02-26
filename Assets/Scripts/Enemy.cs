using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int enemySpeed = 5;
    public int direction = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (enemySpeed * direction, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemies")
        {
            direction *= -1;
        }
    }
}
