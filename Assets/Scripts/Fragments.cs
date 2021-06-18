using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragments : MonoBehaviour
{
    public float min;
    public float max;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(0, transform.position.x );
        float randomY = Random.Range(0, transform.position.y );
        rb2D.velocity = new Vector2(randomX, -randomY *5);
    }

    // Update is called once per frame
    void Update()
    {
        // rb2D.AddForce(Vector2.down * 5 * Time.deltaTime);
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(WaitToDestroy());
        }    
    }
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }    
}
