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
 
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void SetupDirection()
    {

    }    
    // Update is called once per frame
    void LateUpdate()
    {
        if(isTriggerGround)
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
        if(collision.gameObject.CompareTag("Ground"))
        {
            isTriggerGround = true;
            anim.SetBool("isTriggerGround" , true);
            SetupPosition();

           // change to direction if it not right. it's base on the player.  
        }
    }
    
}
