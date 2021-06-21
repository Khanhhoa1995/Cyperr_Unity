using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private bool isTriggerGround;
    private Animator anim;
    public float DefaultSpeed;
    private bool isFired;
    public Transform bulletFire;
   // public PhysicsMaterial2D physicsMaterial2D;
 
 
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(isTriggerGround && !isFired)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    public void SetupPosition()
    {
        if (transform.position.x >= 0.0f)
        {
           
            speed = -DefaultSpeed;
        }
        else
        {
            speed = DefaultSpeed;
        }
       GetComponent<SpriteRenderer>().flipX = speed < 0 ? true : false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !isFired)
        {
            isTriggerGround = true;
            anim.SetBool("isTriggerGround" , true);
            SetupPosition();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if(collision.gameObject.CompareTag("BulletFire"))
        {
            GameManager.instance.UpdateScore(1);
          //  rb2D.velocity = Vector2.zero;
            rb2D.AddForce(transform.up * 5, ForceMode2D.Impulse);
            isFired = true;
            anim.SetBool("isFired", true);
            StartCoroutine(WaitToDestroy());
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if(collision.gameObject.CompareTag("Cat") && isFired)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }    
    }
    IEnumerator WaitToDestroy()
    {
        rb2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }    
    
}
