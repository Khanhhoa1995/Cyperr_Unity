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
        // rb2D.velocity = transform.up * speed;
        isFire = true;
        rb2D.isKinematic = false;
        rb2D.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    isFire = true;
        //    rb2D.isKinematic = false;
        //    rb2D.velocity = transform.up * speed;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Helicopter"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Dog"))
        {
            Destroy(gameObject);
        }    
        // do something helicopter/ solider.
    }
}
