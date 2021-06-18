using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    public bool isFire;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isFire = true;
        rb2D.isKinematic = false;
        rb2D.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float posY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        float posX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        if (transform.position.y > posY || transform.position.x > posX || transform.position.x < -posX) 
        {
            Destroy(gameObject);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Helicopter"))
        {
            Destroy(gameObject);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            Debug.Log("hoaGGGGGG");
            rb2D.velocity = rb2D.velocity * 1.5f;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
